using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class LoginDal
    {
        public Customer Login(string Username, string Pass, List<Customer> customers)
        {
            foreach (var User in customers)
            {
                if (User.UserName == Username)
                {
                    foreach (var pass in customers)
                    {
                        if (User.Pass == Pass)
                        {
                            return User;
                        }
                    }
                    return null;// Console.WriteLine("IncorrectPass");
                }
            }
            return null;//Console.WriteLine("UserDoesNotExist");

        }
    }
}