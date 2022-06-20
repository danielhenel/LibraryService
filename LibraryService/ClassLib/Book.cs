using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public enum Currency
    {
        EUR,
        PLN,
        USD
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BookCategory> Categories { get; set; }
        public List<BookAuthor> Authors { get; set; }
        public int PagesCount { get; set; }
        public float Price { get; set; }
        public Currency Currency { get; set; }

    }
}
