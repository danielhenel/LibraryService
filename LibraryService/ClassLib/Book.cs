using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PagesCount { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; }
    }
}
