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
    public partial class BookDetails : Form
    {

        LibraryServiceContext context = new LibraryServiceContext();
        Book book;
        private float price;
        private int year;
        private float rating;
        private int pagesCount;
        public BookDetails(Book book)
        {
            InitializeComponent();
            this.book = book;
            if(Program.userType == "Admin")
            {
                editButton.Visible = true;
            }
            else
            {
                editButton.Visible = false;

            }

            // disable editing
            saveButton.Visible = false;
            titleBox.Enabled = false;
            yearBox.Enabled = false;
            categoryBox.Enabled = false;
            price1Box.Enabled = false;
            price2Box.Enabled = false;
            price3Box.Enabled = false;
            currencyBox.Enabled = false;
            descriptionBox.Enabled = false;
            authorBox.Enabled = false;
            ratingBox.Enabled = false;
            pagesCountBox.Enabled = false;

            // fill fields
            titleBox.Text = book.Title;
            yearBox.Text = book.Year.ToString();
            BookCategory category = Getter.getCategoryById(book.Id);
            categoryBox.Text = category != null ? category.Name : "";
            price1Box.Text = book.Price.ToString();
            currencyBox.Text = book.Currency;
            upadteCurrencies();
            descriptionBox.Text = book.Description;
            BookAuthor author = Getter.getAuthorById(book.AuthorId);
            authorBox.Text = author != null ? author.Name : "";
            ratingBox.Text = book.Rating.ToString();
            pagesCountBox.Text = book.PagesCount.ToString();
        }
        
        private void upadteCurrencies()
        {
            if (currencyBox.Text == "PLN")
            {
                price2Label.Text = "Price EUR";
                price2Box.Text = convertCurrency("PLN", "EUR", book.Price).ToString();

                price3Label.Text = "Price USD";
                price3Box.Text = convertCurrency("PLN", "USD", book.Price).ToString();

            }
            else if (currencyBox.Text == "EUR")
            {
                price2Label.Text = "Price PLN";
                price2Box.Text = convertCurrency("EUR", "PLN", book.Price).ToString();

                price3Label.Text = "Price USD";
                price3Box.Text = convertCurrency("EUR", "USD", book.Price).ToString();
            }
            else if (currencyBox.Text == "USD")
            {
                price2Label.Text = "Price EUR";
                price2Box.Text = convertCurrency("USD", "EUR", book.Price).ToString();

                price3Label.Text = "Price PLN";
                price3Box.Text = convertCurrency("USD", "PLN", book.Price).ToString();
            }
        }


        private float convertCurrency(string f, string t, float v)
        {
            if (f == "EUR")
            {
                if (t == "PLN")
                {
                    // EUR -> PLN
                    v *= 4.4F;
                }
                else if(t == "USD")
                {
                    // EUR -> USD
                    v *= 1.05F;
                }

            }
            else if (f == "PLN")
            {
                if (t == "USD")
                {
                    // PLN -> USD
                    v *= 0.22F;
                }
                else if (t == "EUR")
                {
                    // PLN -> EUR
                    v *= 0.21F;
                }
            }
            else if (f == "USD")
            {
                if (t == "PLN")
                {
                    // USD -> PLN
                    v *= 4.47F;
                }
                else if(t == "EUR")
                {
                    // USD -> EUR
                    v *= 0.95F;
                }

            }
            return v;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = false;
            saveButton.Visible = true;
            saveButton.Enabled = false;
            //enable editing
            titleBox.Enabled = true;
            yearBox.Enabled = true;
            categoryBox.Enabled = true;
            price1Box.Enabled = true;
            currencyBox.Enabled = true;
            descriptionBox.Enabled = true;
            authorBox.Enabled = true;
            ratingBox.Enabled = true;
            pagesCountBox.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            book.Title = titleBox.Text;
            book.Year = year;
            book.CategoryId = Getter.getCategoryIdByName(categoryBox.Text);
            book.AuthorId = Getter.getAuthorIdByName(authorBox.Text);
            book.Price = price;
            book.Description = descriptionBox.Text;
            book.Rating = rating;
            book.PagesCount = pagesCount;
            context.SaveChanges();
            this.Close();
        }

        private void currencyBox_TextChanged(object sender, EventArgs e)
        {
            upadteCurrencies();
        }

        private void price1Box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                price = float.Parse(price1Box.Text);
                if (price <= 0) { throw new ArgumentOutOfRangeException(); }
                upadteCurrencies();
                label8.Text = "Price";
                label8.ForeColor = Color.FromArgb(0, 0, 0);
                saveButton.Enabled = true;
            }
            catch
            {
                label8.Text = "WRONG PRICE!";
                label8.ForeColor = Color.FromArgb(255, 0, 0);
                saveButton.Enabled = false;
            }
        }

        private void yearBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                year = int.Parse(yearBox.Text);
                if (year <= 0) { throw new ArgumentOutOfRangeException(); }
                label4.Text = "Year";
                label4.ForeColor = Color.FromArgb(0, 0, 0);
                saveButton.Enabled = true;
            }
            catch
            {
                label4.Text = "WRONG YEAR!";
                label4.ForeColor = Color.FromArgb(255, 0, 0);
                saveButton.Enabled = false;
            }
        }

        private void pagesCountBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pagesCount = int.Parse(pagesCountBox.Text);
                if (pagesCount <= 0) { throw new ArgumentOutOfRangeException(); }
                label5.Text = "Pages Count";
                label5.ForeColor = Color.FromArgb(0, 0, 0);
                saveButton.Enabled = true;
            }
            catch
            {
                label5.Text = "WRONG PAGES COUNT!";
                label5.ForeColor = Color.FromArgb(255, 0, 0);
                saveButton.Enabled = false;
            }
        }

        private void ratingBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rating = int.Parse(ratingBox.Text);
                if (rating < 0 || rating > 5) { throw new ArgumentOutOfRangeException(); }
                label3.Text = "Rating";
                label3.ForeColor = Color.FromArgb(0, 0, 0);
                saveButton.Enabled = true;
            }
            catch
            {
                label3.Text = "WRONG RATING VALUE [0,5]!";
                label3.ForeColor = Color.FromArgb(255, 0, 0);
                saveButton.Enabled = false;
            }
        }
    }
}
