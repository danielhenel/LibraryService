using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Getter
    {

        static LibraryServiceContext context = new LibraryServiceContext();

        public static BookCategory getCategoryById(int id)
        {
            return (from category in context.Categories
             where category.Id == id
             select category).SingleOrDefault();
        }

        public static BookAuthor getAuthorById(int id)
        {
            return (from author in context.Authors
                    where author.Id == id
                    select author).SingleOrDefault();
        }

        public static int getCategoryIdByName(string name)
        {
            int id = (from category in context.Categories
             where category.Name == name
             select category.Id).SingleOrDefault();

            if (id == 0)
            {
                //create new category
                BookCategory newCategory = new BookCategory();
                newCategory.Name = name;
                context.Categories.Add(newCategory);
                context.SaveChanges();

                id = (from category in context.Categories
                      where category.Name == name
                      select category.Id).SingleOrDefault();
            }
            return id;
        }

        public static int getAuthorIdByName(string name)
        {
            int id = (from author in context.Authors
                      where author.Name == name
                      select author.Id).SingleOrDefault();
            if(id == 0)
            {
                //create new author
                BookAuthor newAuthor = new BookAuthor();
                newAuthor.Name = name;
                context.Authors.Add(newAuthor);
                context.SaveChanges();

                id = (from author in context.Authors
                          where author.Name == name
                          select author.Id).SingleOrDefault();
            }
            return id;
        }
    }
}
