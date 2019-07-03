using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{


    public class CustomerBL
    {

        public int Create(string lname, string Fname /*string User, string Password*/)
        {
            // Call the DAL to create a new record.
            CustomerDAL customerDAL = new CustomerDAL();
            var custID = customerDAL.CreateCustomer(lname, Fname/*, User, Password*/);
            return custID;
        }

        public Customer Get(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            try
            {
                var customer = dal.Get(id);
                if (customer != null)
                {
                    // Data found. Process it and return to UI.
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log it.
                throw;
            }
        }

        //public List<Customer> GetAll()
        //{
        //    CustomerDAL dal = new CustomerDAL();
        //    var customers = dal.GetAll();
        //    return customers;
        //}
        //public Accounts GetAccountsBL(string AccountID)
        //{
        //    AccountDAL a = new AccountDAL();
        //    var AccountType = a.AccountType(AccountID);
        //    var acc = a.GetAccountsDAL(AccountType, AccountID);
        //    return acc;
        //}

        public void OpenNewAccount(string Account,Customer CustId)
        {
            AccountDAL ADal = new AccountDAL();
            ADal.CreateAccount(Account, CustId);
            CustId.NumberOfAccount++;
        }
        public string CloseAccount(Customer Customer, string AccountID)
        {
            AccountDAL Adal = new AccountDAL();
            string AccountType = Adal.AccountType(AccountID);
            var status = Adal.CloseAccountDAL(AccountType, AccountID, Customer);
            return status;
        }
        public string Withdraw(string AccountID, int Amount, Customer Cust)
        {
            AccountDAL Adal = new AccountDAL();          
            string AccountType = Adal.AccountType(AccountID);
            var status = Adal.WithDrawDAL(AccountType, AccountID, Amount,Cust);
            return status;          
        }
        public string Deposit(string AccountID, int Amount, Customer Cust)
        {
            AccountDAL Adal = new AccountDAL();
            string AccountType = Adal.AccountType(AccountID);
            var status = Adal.DepositDAL(AccountType, AccountID, Amount, Cust);
            Console.WriteLine(status);
            return status;

        }
        public void Transfer(string YourAccountID, string SecondAccountID, int Amount,Customer c)
        {
            AccountDAL Adal = new AccountDAL();
            string AccountType = Adal.AccountType(YourAccountID);
            AccountDAL Bdal = new AccountDAL();
            string Acctypeb = Bdal.AccountType(SecondAccountID);
            var status = Adal.TransferDAL(YourAccountID, AccountType, SecondAccountID, Acctypeb, Amount,c);
            Console.WriteLine(status);
        }
        public string PayLoanInstallement(string AccountId, int Amount, Customer Cust)
        {

            AccountDAL Adal = new AccountDAL();
            var status = Adal.PayLoanInstallementDAL(AccountId, Amount,Cust);
            Console.WriteLine(status);
            return status;
        }
        public Dictionary<int,string> DisplayAccounts(Customer Cust)
        {
            var Adal = new CustomerDAL();
            var list = Adal.DisplayAccountsDAL(Cust);
            return list;
        }
        public List<Transaction> DispalyTransaction(string CustomerId)
        {
            AccountDAL Adal = new AccountDAL();
            List<Transaction> status = Adal.DispalyTransactionDAL(CustomerId);
            return status;
        }
    }     
}
