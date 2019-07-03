using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {

        public string Pass { get; set; }
        public string UserName { get; set; }
        public int AccountBalance { get; set; }
        public string Transaction { get; set; }
        public Dictionary<int,string> Account = new Dictionary<int, string>();
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfAccount { get; set; }

        public Customer(int id, string fname, string lname)
        {
            this.CustomerId = id;
            this.FirstName = fname;
            this.LastName = lname;
        }
        public Customer()
        {

        }

    }
}
