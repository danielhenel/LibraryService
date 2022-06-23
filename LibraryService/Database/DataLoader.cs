using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using ClassLib;
using System.IO;

namespace Database
{
    public static class DataLoader
    {
        public static void loadData()
        {
            Console.WriteLine("START");
            LibraryServiceContext context = new LibraryServiceContext();
            string path = Directory.GetCurrentDirectory() + @"\data\books.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    Book book = new Book();
                    string[] fields = csvParser.ReadFields();
                    //title
                    string title = fields[0];
                    book.Title = title;
                    //authors
                    string[] Authors = fields[1].Split(',');
                

                    var AuthorId = (from author in context.Authors
                                where author.Name == Authors[0]
                                select author.Id).SingleOrDefault();
                    if(AuthorId != 0){
                        book.AuthorId = AuthorId;
                    }
                    else
                    {
                        BookAuthor b = new BookAuthor();
                        b.Name = Authors[0];
                        context.Authors.Add(b);
                        context.SaveChanges();
                        var id = (from author in context.Authors
                                        where author.Name == Authors[0]
                                        select author.Id).SingleOrDefault();
                        book.AuthorId = id;
                    }


                        //categories
                        string[] Categories = fields[2].Split(',');

                    var CategoryId = (from category in context.Categories
                                    where category.Name == Categories[0]
                                    select category.Id).SingleOrDefault();
                    if (CategoryId != 0)
                    {
                        book.CategoryId = CategoryId;
                    }
                    else
                    {
                        BookCategory b = new BookCategory();
                        b.Name = Categories[0];
                        context.Categories.Add(b);
                        context.SaveChanges();
                        var id = (from category in context.Categories
                                          where category.Name == Categories[0]
                                          select category.Id).SingleOrDefault();
                        book.CategoryId = id;
                    }

                    //description
                    string description = fields[3];
                        book.Description = description;
                    try
                    {
                        //year
                        int year = int.Parse(fields[4]);
                        book.Year = year;
                    }
                    catch
                    {
                        book.Year = 2022;
                    }
                    //rateing
                    try
                    {
                        float rating = float.Parse(fields[5]);
                        book.Rating = rating;
                    }
                    catch
                    {
                        book.Rating = 0;
                    }
                    try
                    {
                        //pagesCount
                        int pagesCount = int.Parse(fields[6]);
                        book.PagesCount = pagesCount;
                    }
                    catch
                    {
                        book.PagesCount = 0;
                    }
                        //random price
                        Random rnd = new Random();
                        int price = rnd.Next(20, 100);
                        book.Price = price;

                        //random currencies
                        int index = rnd.Next(0, 3);
                        if (index == 0) book.Currency = "PLN";
                        else if (index == 1) book.Currency = "EUR";
                        else if (index == 2) book.Currency = "USD";

                        context.Books.Add(book);
                }
             }
            context.SaveChanges();
            Console.WriteLine("END");
        }
    }
}
