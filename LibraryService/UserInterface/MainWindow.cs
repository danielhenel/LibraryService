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

            /*var categories = (from category in context.Categories
                              select category.Name).ToArray();

            if (categories!=null) categoryBox.Items.AddRange(categories);
            var years = (from book in context.Books
                         select book.Year.ToString()).ToArray();
            if (years != null) yearBox.Items.AddRange(years);
            Books = (from book in context.Books
                            select book).ToList();
            Console.WriteLine(context);*/
            //showBooks();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage == firstPage) previousButton.Enabled = false;
            nextButton.Enabled = true;
            showBooks();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage == lastPage) nextButton.Enabled = false;
            previousButton.Enabled = true;
            showBooks();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var title = titleTexBox.Text;
            var author = authorTextBox.Text;
            var category = categoryBox.Text;
            var year = -1;
            try
            {
                year = int.Parse(yearBox.Text);
            }
            catch
            {
                year = -1;
            }

            var rating_from = -1;
            var rating_to = -1;
            if (ratingBox.Text == @"[0,1)") { rating_from = 0; rating_to = 1; }
            else if (ratingBox.Text == @"[1,2)") { rating_from = 1; rating_to = 2; }
            else if (ratingBox.Text == @"[2,3)") { rating_from = 2; rating_to = 3; }
            else if (ratingBox.Text == @"[3,4)") { rating_from = 3; rating_to = 4; }
            else if (ratingBox.Text == @"[4,5)") { rating_from = 4; rating_to = 5; }

            var price_from = -1;
            var price_to = -1;
            if (priceBox.Text == @"<30") { price_to = 30; }
            else if (priceBox.Text == @"(30,50]") { price_from = 30; price_to = 50; }
            else if (priceBox.Text == @"(50,70]") { price_from = 50; price_to = 70; }
            else if (priceBox.Text == @"(70,90]") { price_from = 70; price_to = 90; }
            else if (priceBox.Text == @">90") { price_from = 90; }

            var currency = currencyBox.Text;

            Books = (from book in context.Books
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

                // 
                // detailsButton
                // 
                Button detailsButton = new Button();
                detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                detailsButton.Location = new System.Drawing.Point(736, 10);
                detailsButton.Size = new System.Drawing.Size(79, 56);
                detailsButton.Text = "Details";
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
                panel1.Location = new System.Drawing.Point(484, 3);
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
                               where category.Id == Books[i].AuthorId
                               select category.Name).SingleOrDefault();
                label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel3 = new Panel();
                panel3.BackColor = System.Drawing.Color.SandyBrown;
                panel3.Location = new System.Drawing.Point(3, 3);
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

        }

        private void detailsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
