using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public enum Role
    {
        ADMIN,
        USER
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<HistoryItem> History { get; set; }

        public override string ToString()
        {
            string msg = this.Name + " " + this.Surname;
            return msg;
        }
    }
}
