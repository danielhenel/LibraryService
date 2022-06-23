using ClassLib;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class Login : Form
    {
        MainWindow parent;
        public Login(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Register form = new Register();
            form.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = Getter.getUserByLogin(loginTextBox.Text);
            if(user == null)
            {
                MessageBox.Show("Incorrect login. User not found.");
            }
            else
            {
                if(verifyPassword(user.Password, passwordTextBox.Text))
                {
                    this.Close();
                    Program.user = user;
                    Program.userType = user.Role;
                    if (Program.user != null)
                    {
                        parent.getChangePanelButton().Text = Program.user.Name;
                        parent.getChangePanelButton().Visible = true;
                        parent.getLogoutButton().Visible = true;
                        parent.getLoginButton().Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
        }

        public bool verifyPassword(string hashed, string password)
        {
            var tab = hashed.Split(':');
            var salt = Convert.FromBase64String(tab[1]);

            password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 300000,
                numBytesRequested: 256 / 8));

            if (tab[0] == password)
            {
                return true;
            }
            return false;
        }

    }
}
