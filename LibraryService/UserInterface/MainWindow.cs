using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.ServiceReference;

namespace UserInterface
{
    public partial class MainWindow : Form
    {
        private LibraryClient client = new LibraryClient();
        LibraryServiceContext context = new LibraryServiceContext();
        private List<Book> Books;
        int firstPage;
        int currentPage;
        int lastPage;
        public MainWindow()
        {
            InitializeComponent();

            var categories = (from category in context.Categories
                              select category.Name).ToArray();

            if (categories!=null) categoryBox.Items.AddRange(categories);
            var years = (from book in context.Books
                         select book.Year.ToString()).ToArray();
            if (years != null) yearBox.Items.AddRange(years);

            Books = (from book in context.Books
                            select book).ToList();

            currentPage = 1;
            lastPage = Books.Count() % 5 == 0 ? Books.Count() : Books.Count() + 1;
            firstPage = 1;
            previousButton.Enabled = false;
            currentPage = 1;
            if (lastPage > currentPage) { nextButton.Enabled = true; }
            else nextButton.Enabled = false;
            logoutButton.Visible = false;

            showBooks();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (currentPage == firstPage)
            {
                previousButton.Enabled = false;
                return;
            }
            currentPage--;
            nextButton.Enabled = true;
            label11.Text = currentPage.ToString();
            showBooks();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentPage == lastPage)
            {
                nextButton.Enabled = false;
                return;
            }
            currentPage++;
            previousButton.Enabled = true;
            label11.Text = currentPage.ToString();
            showBooks();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string title = titleTexBox.Text;
            string author = authorTextBox.Text;
            int authorId = (from a in context.Authors
                            where a.Name == author
                            select a.Id).SingleOrDefault();
            string category = categoryBox.Text;
            int categoryId = (from cat in context.Categories
                              where cat.Name == category
                              select cat.Id).SingleOrDefault();
            int year = 0;
            try
            {
                year = int.Parse(yearBox.Text);
            }
            catch
            {
                year = 0;
            }

            int rating_from = -1;
            int rating_to = -1;
            if (ratingBox.Text == @"[0,1)") { rating_from = 0; rating_to = 1; }
            else if (ratingBox.Text == @"[1,2)") { rating_from = 1; rating_to = 2; }
            else if (ratingBox.Text == @"[2,3)") { rating_from = 2; rating_to = 3; }
            else if (ratingBox.Text == @"[3,4)") { rating_from = 3; rating_to = 4; }
            else if (ratingBox.Text == @"[4,5)") { rating_from = 4; rating_to = 5; }

            int price_from = -1;
            int price_to = -1;
            if (priceBox.Text == @"<30") { price_to = 30; }
            else if (priceBox.Text == @"(30,50]") { price_from = 30; price_to = 50; }
            else if (priceBox.Text == @"(50,70]") { price_from = 50; price_to = 70; }
            else if (priceBox.Text == @"(70,90]") { price_from = 70; price_to = 90; }
            else if (priceBox.Text == @">90") { price_from = 90; }

            string currency = currencyBox.Text;

            Books = (from book in context.Books
                     where (title != "" ? book.Title == title : true)
                     && (author != "" ? book.AuthorId == authorId : true)
                     && (category != "" ? book.CategoryId == categoryId : true)
                     && (year != 0 ? book.Year == year : true)
                     && (rating_from != -1 ? book.Rating >= rating_from : true)
                     && (rating_to != -1 ? book.Rating < rating_to : true)
                     && (price_from != -1 ? book.Price > price_from : true)
                     && (price_to != -1 ? book.Price <= price_to : true)
                     && (currency != "" ? book.Currency == currency : true)
                     select book).ToList();

            lastPage = Books.Count() % 5 == 0 ? Books.Count() : Books.Count() + 1;
            firstPage = 1;
            previousButton.Enabled = false;
            currentPage = 1;
            if (lastPage > currentPage) { nextButton.Enabled = true; }
            else nextButton.Enabled = false;

            showBooks();
        }

        void showBooks()
        {
            flowLayoutPanel2.Controls.Clear();
            if (Books.Count() == 0) return;

            int start = currentPage * 5 - 5;
            int end = currentPage * 5 - 1;
            int i = start;
            while (i <= end && i < Books.Count())
            {
                // 
                // followButton
                // 
                Button followButton = new Button();
                followButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                followButton.Location = new System.Drawing.Point(821, 10);
                followButton.Size = new System.Drawing.Size(79, 56);
                followButton.Text = "Follow";
                followButton.UseVisualStyleBackColor = true;
                followButton.Click += new System.EventHandler(this.followButton_Click);
                followButton.Tag = Books[i];


                // 
                // detailsButton
                // 
                Button detailsButton = new Button();
                detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                detailsButton.Location = new System.Drawing.Point(736, 10);
                detailsButton.Size = new System.Drawing.Size(79, 56);
                detailsButton.Text = "Details";
                detailsButton.Tag = Books[i];
                detailsButton.UseVisualStyleBackColor = true;
                detailsButton.Click += new System.EventHandler(this.detailsButton_Click);

                // 
                // title
                // 
                label1 = new Label();
                label1.Dock = System.Windows.Forms.DockStyle.Fill;
                label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Size = new System.Drawing.Size(236, 71);
                label1.Text = Books[i].Title;
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel1 = new Panel();
                panel1.BackColor = System.Drawing.Color.SandyBrown;
                panel1.Location = new System.Drawing.Point(3, 3);
                panel1.Size = new System.Drawing.Size(236, 71);
                panel1.Controls.Add(label1);

                // 
                // author
                // 
                label2 = new Label();
                label2.Dock = System.Windows.Forms.DockStyle.Fill;
                label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(0, 0);
                label2.Size = new System.Drawing.Size(236, 71);
                label2.Text = (from author in context.Authors
                               where author.Id == Books[i].AuthorId
                               select author.Name).SingleOrDefault();
                label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel2 = new Panel();
                panel2.BackColor = System.Drawing.Color.SandyBrown;
                panel2.Location = new System.Drawing.Point(242, 3);
                panel2.Size = new System.Drawing.Size(236, 71);
                panel2.Controls.Add(label2);

                // 
                // category
                // 
                label3 = new Label();
                label3.Dock = System.Windows.Forms.DockStyle.Fill;
                label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new System.Drawing.Point(0, 0);
                label3.Size = new System.Drawing.Size(236, 71);
                label3.Text = (from category in context.Categories
                               where category.Id == Books[i].CategoryId
                               select category.Name).SingleOrDefault();
                label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel3 = new Panel();
                panel3.BackColor = System.Drawing.Color.SandyBrown;
                panel3.Location = new System.Drawing.Point(484, 3);
                panel3.Size = new System.Drawing.Size(236, 71);
                panel3.Controls.Add(label3);


                //
                // panel
                //
                Panel panel = new Panel();
                panel.Controls.Add(followButton);
                panel.Controls.Add(detailsButton);
                panel.Controls.Add(panel1);
                panel.Controls.Add(panel2);
                panel.Controls.Add(panel3);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Size = new System.Drawing.Size(921, 77);

                flowLayoutPanel2.Controls.Add(panel);
                i++;
            }
        }

        private void followButton_Click(object sender, EventArgs e)
        {
            if (Program.user == null) return;
            Subscription sub = new Subscription
            {
                BookId = ((Book)((Button)sender).Tag).Id,
                UserId = Program.user.Id
            };
            context.Subscriptions.Add(sub);
            context.SaveChanges();
            MessageBox.Show("Followed");
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            BookDetails form = new BookDetails((Book)((Button)sender).Tag);
            form.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login form = new Login(this);
            form.Show();
        }

        private void changePanelButton_Click(object sender, EventArgs e)
        {
            if(Program.user != null)
            {
                if(Program.user.Role == "User")
                {
                    UserPanel panel = new UserPanel();
                    panel.Show();
                }
                else if(Program.user.Role == "Admin")
                {
                    AdminPanel panel = new AdminPanel();
                    panel.Show();
                }
            }
        }

        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            Program.user = null;
            Program.userType = "Guest";
            loginButton.Visible = true;
            logoutButton.Visible = false;
            changePanelButton.Visible = false;
        }

        public Button getChangePanelButton()
        {
            return changePanelButton;
        }

        public Button getLoginButton()
        {
            return loginButton;
        }

        public Button getLogoutButton()
        {
            return logoutButton;
        }
    }
}
