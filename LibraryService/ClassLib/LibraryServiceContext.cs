using ClassLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class LibraryServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryService;",
                builder => builder.EnableRetryOnFailure());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookAuthor> Authors { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<HistoryItem> History { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CurrentOnLoanBook> CurrentOnLoanBooks { get; set; }

    }
}
