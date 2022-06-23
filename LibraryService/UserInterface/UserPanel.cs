using ClassLib;
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
    public partial class UserPanel : Form
    {

        LibraryServiceContext context = new LibraryServiceContext();
        List<CurrentOnLoanBook> BooksOnLoan = Getter.getUsersCurrentOnLoanBooksByUserId(Program.user.Id);
        List<HistoryItem> FollowedBooks = Getter.getUsersHistoryByUserId(Program.user.Id);
        List<HistoryItem> BooksHistory = Getter.getUsersHistoryByUserId(Program.user.Id);
        int firstPage;
        int currentPage;
        int lastPage;
        string state = "";
        public UserPanel()
        {
            InitializeComponent();
            currentPage = 1;
        }

        private void onLoanButton_Click(object sender, EventArgs e)
        {
            lastPage = BooksOnLoan.Count() % 5 == 0 ? BooksOnLoan.Count() : BooksOnLoan.Count() + 1;
            firstPage = 1;
            previousButton.Enabled = false;
            currentPage = 1;
            if (lastPage > currentPage) { nextButton.Enabled = true; }
            else nextButton.Enabled = false;
            changeButtonsColor("OnLoan");
            showBooksOnLoan();
            state = "OnLoan";
        }

        private void followedButton_Click(object sender, EventArgs e)
        {
            lastPage = FollowedBooks.Count() % 5 == 0 ? FollowedBooks.Count() : FollowedBooks.Count() + 1;
            firstPage = 1;
            previousButton.Enabled = false;
            currentPage = 1;
            if (lastPage > currentPage) { nextButton.Enabled = true; }
            else nextButton.Enabled = false;
            changeButtonsColor("Follow");
            showFollowedBooks();
            state = "Follow";
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            lastPage = BooksHistory.Count() % 5 == 0 ? BooksHistory.Count() : BooksHistory.Count() + 1;
            firstPage = 1;
            previousButton.Enabled = false;
            currentPage = 1;
            if (lastPage > currentPage) { nextButton.Enabled = true; }
            else nextButton.Enabled = false;
            changeButtonsColor("History");
            showHistory();
            state = "History";
        }

        private void changeButtonsColor(string buttonName)
        {
            if(buttonName == "OnLoan")
            {
                followedButton.BackColor = System.Drawing.Color.SandyBrown;
                historyButton.BackColor = System.Drawing.Color.SandyBrown;
                onLoanButton.BackColor = System.Drawing.Color.OrangeRed;
            }
            else if(buttonName == "Follow")
            {
                followedButton.BackColor = System.Drawing.Color.OrangeRed;
                historyButton.BackColor = System.Drawing.Color.SandyBrown;
                onLoanButton.BackColor = System.Drawing.Color.SandyBrown;
            }
            else if(buttonName == "History")
            {
                followedButton.BackColor = System.Drawing.Color.SandyBrown;
                historyButton.BackColor = System.Drawing.Color.OrangeRed;
                onLoanButton.BackColor = System.Drawing.Color.SandyBrown;
            }
        }

        private void showBooksOnLoan()
        {
            if (BooksOnLoan.Count() == 0) return;

            flowLayoutPanel2.Controls.Clear();


            int start = currentPage * 5 - 5;
            int end = currentPage * 5 - 1;
            int i = start;
            while (i <= end && i < BooksOnLoan.Count())
            {
                Book currentBook = Getter.getBookById(BooksOnLoan[i].BookId);
                // 
                // renewButton
                // 
                Button renewButton = new Button();
                renewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                renewButton.Location = new System.Drawing.Point(1078, 10);
                renewButton.Size = new System.Drawing.Size(79, 56);
                renewButton.Text = "Renew";
                renewButton.UseVisualStyleBackColor = true;
                renewButton.Click += new System.EventHandler(this.renewButton_Click);
                renewButton.Tag = BooksOnLoan[i];

                // 
                // detailsButton
                // 
                Button detailsButton = new Button();
                detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                detailsButton.Location = new System.Drawing.Point(993, 10);
                detailsButton.Size = new System.Drawing.Size(79, 56);
                detailsButton.Text = "Details";
                detailsButton.Tag = currentBook;
                detailsButton.UseVisualStyleBackColor = true;
                detailsButton.Click += new System.EventHandler(this.detailsButton_Click);

                // 
                // title
                // 
                Label label1 = new Label();
                label1.Dock = System.Windows.Forms.DockStyle.Fill;
                label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Size = new System.Drawing.Size(236, 71);
                label1.Text = currentBook.Title;
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel1 = new Panel();
                panel1.BackColor = System.Drawing.Color.SandyBrown;
                panel1.Location = new System.Drawing.Point(3, 3);
                panel1.Size = new System.Drawing.Size(236, 71);
                panel1.Controls.Add(label1);

                // 
                // author
                // 
                Label label2 = new Label();
                label2.Dock = System.Windows.Forms.DockStyle.Fill;
                label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(0, 0);
                label2.Size = new System.Drawing.Size(236, 71);
                label2.Text = Getter.getAuthorById(currentBook.AuthorId).Name;
                label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel2 = new Panel();
                panel2.BackColor = System.Drawing.Color.SandyBrown;
                panel2.Location = new System.Drawing.Point(242, 3);
                panel2.Size = new System.Drawing.Size(236, 71);
                panel2.Controls.Add(label2);

                // 
                // category
                // 
                Label label3 = new Label();
                label3.Dock = System.Windows.Forms.DockStyle.Fill;
                label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new System.Drawing.Point(0, 0);
                label3.Size = new System.Drawing.Size(236, 71);
                label3.Text = Getter.getCategoryById(currentBook.CategoryId).Name;
                label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel3 = new Panel();
                panel3.BackColor = System.Drawing.Color.SandyBrown;
                panel3.Location = new System.Drawing.Point(484, 3);
                panel3.Size = new System.Drawing.Size(236, 71);
                panel3.Controls.Add(label3);


                // 
                // end date
                // 
                Label label4 = new Label();
                label4.Dock = System.Windows.Forms.DockStyle.Fill;
                label4.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label4.Location = new System.Drawing.Point(0, 0);
                label4.Size = new System.Drawing.Size(236, 71);
                label4.Text = Getter.getCurrentOnLoanBookByBookId(BooksOnLoan[i].Id).endDate.ToString();
                label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel4 = new Panel();
                panel4.BackColor = System.Drawing.Color.SandyBrown;
                panel4.Location = new System.Drawing.Point(726, 3);
                panel4.Size = new System.Drawing.Size(236, 71);
                panel4.Controls.Add(label3);

                //
                // panel
                //
                Panel panel = new Panel();
                panel.Controls.Add(renewButton);
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

        private void showFollowedBooks()
        {
            if (FollowedBooks.Count() == 0) return;

            flowLayoutPanel2.Controls.Clear();


            int start = currentPage * 5 - 5;
            int end = currentPage * 5 - 1;
            int i = start;
            while (i <= end && i < FollowedBooks.Count())
            {
                Book currentBook = Getter.getBookById(FollowedBooks[i].BookId);
                // 
                // unfollowButton
                // 
                Button unfollowButton = new Button();
                unfollowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                unfollowButton.Location = new System.Drawing.Point(821, 10);
                unfollowButton.Size = new System.Drawing.Size(79, 56);
                unfollowButton.Text = "Unfollow";
                unfollowButton.UseVisualStyleBackColor = true;
                unfollowButton.Click += new System.EventHandler(this.unfollowButtonButton_Click);
                unfollowButton.Tag = FollowedBooks[i];

                // 
                // detailsButton
                // 
                Button detailsButton = new Button();
                detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                detailsButton.Location = new System.Drawing.Point(736, 10);
                detailsButton.Size = new System.Drawing.Size(79, 56);
                detailsButton.Text = "Details";
                detailsButton.Tag = currentBook;
                detailsButton.UseVisualStyleBackColor = true;
                detailsButton.Click += new System.EventHandler(this.detailsButton_Click);

                // 
                // title
                // 
                Label label1 = new Label();
                label1.Dock = System.Windows.Forms.DockStyle.Fill;
                label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Size = new System.Drawing.Size(236, 71);
                label1.Text = currentBook.Title;
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel1 = new Panel();
                panel1.BackColor = System.Drawing.Color.SandyBrown;
                panel1.Location = new System.Drawing.Point(3, 3);
                panel1.Size = new System.Drawing.Size(236, 71);
                panel1.Controls.Add(label1);

                // 
                // author
                // 
                Label label2 = new Label();
                label2.Dock = System.Windows.Forms.DockStyle.Fill;
                label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(0, 0);
                label2.Size = new System.Drawing.Size(236, 71);
                label2.Text = Getter.getAuthorById(currentBook.AuthorId).Name;
                label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel2 = new Panel();
                panel2.BackColor = System.Drawing.Color.SandyBrown;
                panel2.Location = new System.Drawing.Point(242, 3);
                panel2.Size = new System.Drawing.Size(236, 71);
                panel2.Controls.Add(label2);

                // 
                // category
                // 
                Label label3 = new Label();
                label3.Dock = System.Windows.Forms.DockStyle.Fill;
                label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new System.Drawing.Point(0, 0);
                label3.Size = new System.Drawing.Size(236, 71);
                label3.Text = Getter.getCategoryById(currentBook.CategoryId).Name;
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
                panel.Controls.Add(unfollowButton);
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

        private void showHistory()
        {
            if (BooksHistory.Count() == 0) return;

            flowLayoutPanel2.Controls.Clear();


            int start = currentPage * 5 - 5;
            int end = currentPage * 5 - 1;
            int i = start;
            while (i <= end && i < BooksHistory.Count())
            {
                Book currentBook = Getter.getBookById(BooksHistory[i].BookId);

                // 
                // detailsButton
                // 
                Button detailsButton = new Button();
                detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                detailsButton.Location = new System.Drawing.Point(1078, 10);
                detailsButton.Size = new System.Drawing.Size(79, 56);
                detailsButton.Text = "Details";
                detailsButton.Tag = currentBook;
                detailsButton.UseVisualStyleBackColor = true;
                detailsButton.Click += new System.EventHandler(this.detailsButton_Click);

                // 
                // title
                // 
                Label label1 = new Label();
                label1.Dock = System.Windows.Forms.DockStyle.Fill;
                label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Size = new System.Drawing.Size(236, 71);
                label1.Text = currentBook.Title;
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel1 = new Panel();
                panel1.BackColor = System.Drawing.Color.SandyBrown;
                panel1.Location = new System.Drawing.Point(3, 3);
                panel1.Size = new System.Drawing.Size(236, 71);
                panel1.Controls.Add(label1);

                // 
                // author
                // 
                Label label2 = new Label();
                label2.Dock = System.Windows.Forms.DockStyle.Fill;
                label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(0, 0);
                label2.Size = new System.Drawing.Size(236, 71);
                label2.Text = Getter.getAuthorById(currentBook.AuthorId).Name;
                label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel2 = new Panel();
                panel2.BackColor = System.Drawing.Color.SandyBrown;
                panel2.Location = new System.Drawing.Point(242, 3);
                panel2.Size = new System.Drawing.Size(236, 71);
                panel2.Controls.Add(label2);

                // 
                // category
                // 
                Label label3 = new Label();
                label3.Dock = System.Windows.Forms.DockStyle.Fill;
                label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new System.Drawing.Point(0, 0);
                label3.Size = new System.Drawing.Size(236, 71);
                label3.Text = Getter.getCategoryById(currentBook.CategoryId).Name;
                label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel3 = new Panel();
                panel3.BackColor = System.Drawing.Color.SandyBrown;
                panel3.Location = new System.Drawing.Point(484, 3);
                panel3.Size = new System.Drawing.Size(236, 71);
                panel3.Controls.Add(label3);


                // 
                // loan period
                // 
                Label label4 = new Label();
                label4.Dock = System.Windows.Forms.DockStyle.Fill;
                label4.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label4.Location = new System.Drawing.Point(0, 0);
                label4.Size = new System.Drawing.Size(350, 71);
                label4.Text = BooksHistory[i].LoanStartDate.ToString() + " - " + BooksHistory[i].LoanEndDate.ToString();
                label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Panel panel4 = new Panel();
                panel4.BackColor = System.Drawing.Color.SandyBrown;
                panel4.Location = new System.Drawing.Point(726, 3);
                panel4.Size = new System.Drawing.Size(236, 71);
                panel4.Controls.Add(label3);

                //
                // panel
                //
                Panel panel = new Panel();
                panel.Controls.Add(renewButton);
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

        private void detailsButton_Click(object sender, EventArgs e)
        {
            BookDetails form = new BookDetails((Book)((Button)sender).Tag);
            form.Show();
        }

        private void renewButton_Click(object sender, EventArgs e)
        {
            CurrentOnLoanBook book = (CurrentOnLoanBook)((Button)sender).Tag;
            if(book.numberOfRenews == 3)
            {
                MessageBox.Show("Renew impossible! Limit of renews: 3");
            }
            else
            {
                book.numberOfRenews++;
                book.endDate.AddDays(30);
                context.SaveChanges();
                string message = "Loan end date has been changed : " + book.endDate.ToString();
                MessageBox.Show(message);
                //update table
                Point endDateLocation = new System.Drawing.Point(726, 3);
                Label label = (Label)((Panel)((Panel)(((Button)sender).Parent).GetChildAtPoint(endDateLocation))).Controls[0];
                label.Text = book.endDate.ToString();
            }
        }


        private void unfollowButtonButton_Click(object sender, EventArgs e)
        {
            context.Subscriptions.Remove((Subscription)((((Button)sender)).Tag));
            MessageBox.Show("Unfollowed!");
            context.SaveChanges();
            //update table
            this.Controls.Remove(((Panel)(((Button)sender).Parent)));
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
            if (state == "OnLoan")
            {
                showBooksOnLoan();
            }
            else if (state == "Follow")
            {
                showFollowedBooks();
            }
            else if(state == "History")
            {
                showHistory();
            }
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
            if (state == "OnLoan")
            {
                showBooksOnLoan();
            }
            else if (state == "Follow")
            {
                showFollowedBooks();
            }
            else if (state == "History")
            {
                showHistory();
            }
        }

    }
}
