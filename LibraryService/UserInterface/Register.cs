using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace UserInterface
{
    public partial class Register : Form
    {
        LibraryServiceContext context = new LibraryServiceContext();
        
        public Register()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Text != "" && nameTextBox.Text != ""
                && surnameTextBox.Text != "" && (Program.userType == "Admin" ? roleComboBox.SelectedText != "" : true))
                createUser();
            else MessageBox.Show("You have to fill all fields!");
        }

        public void createUser()
        {
            User user = Getter.getUserByLogin(loginTextBox.Text);


                if (user == null)
                {
                string role;

                    if (Program.userType == "Admin") role = roleComboBox.SelectedText; 
                    else role = "User";

                    user = new User
                    {

                        Login = loginTextBox.Text,
                        Password = hashPassword(passwordTextBox.Text),
                        Name = nameTextBox.Text,
                        Surname = surnameTextBox.Text,
                        Role = role


                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                
                    MessageBox.Show("Account Created");
                this.Close();
                }
                else
                {
                MessageBox.Show("Incorrect Login");
                }
        }

        public static string hashPassword(string password)
        {
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(Program.salt);

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Program.salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 300000,
                    numBytesRequested: 256 / 8));

                return $"{hashed}:{Convert.ToBase64String(Program.salt)}";
            }
        }

        public static void createAdminIfNotExist()
        {
            List<User> users = Getter.getUsers();
            LibraryServiceContext context = new LibraryServiceContext();

            if (users.Count == 0)
            {
                User user = new User
                {

                    Login = "admin",
                    Password = hashPassword("admin"),
                    Name = "admin",
                    Surname = "admin",
                    Role = "Admin"

                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
