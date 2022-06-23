using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class CurrentOnLoanBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int numberOfRenews { get; set; }
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
