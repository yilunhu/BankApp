using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        static int IDCOUNT = 10;
        static List<Customer> AllCustomer = new List<Customer>(){
                new Customer { CustomerId=101, FirstName="John", LastName="Smith" },
                new Customer { CustomerId=102, FirstName="Mary", LastName="Jane" },
                new Customer { CustomerId=103, FirstName="Fred", LastName="Smith" }
            };

        public Dictionary<int,string> DisplayAccountsDAL(Customer Cust)
        {
            foreach (var item in AllCustomer)
            {
                if(item.CustomerId == Cust.CustomerId)
                {
                    return item.Account;
                }
            }
            return null;
        }
        public int CreateCustomer(string lname, string Fname/*, string User, string Password*/)
        {
            Customer c1 = new Customer()
            {
                CustomerId = IDCOUNT,
                FirstName = Fname,
                LastName = lname,
                //UserName = User,
                //Pass = Password,
                NumberOfAccount = 0 
            };
            AllCustomer.Add(c1);
            IDCOUNT = IDCOUNT + 10;
            return c1.CustomerId;
        }

        public Customer Get(int id)
        {
            // Connect to DB, search for record with matching id.
            foreach (var Item in AllCustomer)
            {
                if (id == (int)Item.CustomerId)
                {
                    return Item;
                }
            }
            return null;
        }

        //public List<Customer> GetAll()
        //{
        //    // Connect to the DB and fetch all Customer records.          
        //    return AllCustomer;
        //}

    }
}
