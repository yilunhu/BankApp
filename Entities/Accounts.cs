using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Accounts
    {
        public int AccountId { get; set; }
        public int CustomerId;
  
        public DateTime CreationDate { get; set; }
        public double InterestRate = 0.15;
        public int Balance;

    }
    public class Loan : Accounts
    {
        public int LoanLimit { get; set; }
        public string AccountType = "Loan"; 

    }
    public class Checking : Accounts
    {
        public string AccountType = "Checking";
    }
    public class Business : Accounts
    {
        public int Overdraw = 200;
        public string AccountType = "Business";

    }
    public class TermDeposit : Accounts
    {
        public int TermDepositAmount = 1000;
        public string AccountType = "TermDeposit";
        public DateTime Maturity;
    }
}
