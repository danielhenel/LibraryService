using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserApp.ServiceReference;

namespace UserApp
{
    public partial class Test : Form
    {
        static LibraryClient client;
        public Test(LibraryClient cli)
        {
            client = cli;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = client.GetData(77);
        }

        private void followButton_Click(object sender, EventArgs e)
        {

        }
    }
}
