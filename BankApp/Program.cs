using Entities;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string Continue = null;
            string Continue1 = null;
            Console.WriteLine("Welcome to Yi'S Central Bank!");
            do
            {
                Console.WriteLine("New User Enter: 1 \nExisitng User Enter: 2");
                string UserType = Console.ReadLine();
                switch (UserType)
                {
                    case "1":
                        //Console.WriteLine("Please Set your username: ");
                        //string User = Console.ReadLine();
                        //Console.WriteLine("Please set your Password: ");
                        //string pass = Console.ReadLine();
                        Console.WriteLine("Please Enter your First Name: ");
                        string FirstName =  Console.ReadLine();
                        Console.WriteLine("Please Enter your Last Name: ");
                        string LastName = Console.ReadLine();
                        CustomerBL CreateC = new CustomerBL();
                        var x=  CreateC.Create(LastName, FirstName /*,User, pass*/);
                        Console.WriteLine($"Your CustomerID is {x}");
                        break;
                    case "2":
                        Console.WriteLine("Please Enter You Customer ID: ");
                        string a = Console.ReadLine();
                        int b = Convert.ToInt32(a);
                        var c = new CustomerBL().Get(b);
                        Console.WriteLine($"Id: {c.CustomerId} - Firstname: {c.FirstName} - Lastname: {c.LastName} - Number of account {c.NumberOfAccount}");
                        Console.WriteLine("Press 1 to Open an account\n2 to manage account\nEnter anyother value to discontinue...");
                        string NewAccount = Console.ReadLine();
                        switch (NewAccount)
                        {
                            case "1":
                                var OpenAccount = new CustomerBL();
                                Console.WriteLine("Enter 1 For Checking,\n2 For Business,\n3 For Loan,\n4 For Term Deposit");
                                string AccountType = Console.ReadLine();
                                if (AccountType == "1" || AccountType == "2" || AccountType == "3" || AccountType == "4")
                                {
                                    var AccInfo = OpenAccount.OpenNewAccount(AccountType, c);
                                    Console.WriteLine("Account Created...");
                                    Console.WriteLine($"Your account Id is {AccInfo.AccountId}");
                                    
                                }
                                else {
                                    Console.WriteLine("You have enter a Invalid Input");
                                }
                                break;
                            case "2":                             
                                    var GetAccounts = new CustomerBL();
                                    var ListOfAccount = GetAccounts.DisplayAccounts(c);
                                //do { 
                                    Console.WriteLine("List of your Account...");
                                    foreach (var item in ListOfAccount)
                                    {
                                        Console.WriteLine($"AccountID -{item.Key} Account Type -{item.Value}");
                                    }
                                    Console.WriteLine("Enter: 1- Deposit, 2-withdraw, 3-Transfer money, 4-delete account, 5-Display Transaction");
                                    string statement = Console.ReadLine();
                                    switch (statement)
                                    {
                                        case "1": //deposit
                                            Console.WriteLine("Plese Select an account by entering the accountId: ");
                                            string AccountId = Console.ReadLine();
                                            Console.WriteLine("Plese Enter the amount deposite: ");
                                            string Amount = Console.ReadLine();
                                            GetAccounts.Deposit(AccountId, Amount, c);
                                            break;

                                        case "2": //withdraw
                                            Console.WriteLine("Plese select an account by entering the accountId: ");
                                            AccountId = Console.ReadLine();
                                            Console.WriteLine("Plese Enter the amount withdraw: ");
                                            Amount = Console.ReadLine();
                                            GetAccounts.Withdraw(AccountId, Convert.ToInt32(Amount), c);
                                            break;
                                        case "3": //transfer
                                            Console.WriteLine("Plese select an account by entering the accountId: ");
                                            AccountId = Console.ReadLine();
                                            Console.WriteLine("Plese Enter the traget accountId: ");
                                            string AccountIdB = Console.ReadLine();
                                            Console.WriteLine("Plese Enter the amount transfer: ");
                                            Amount = Console.ReadLine();
                                            GetAccounts.Transfer(AccountId, AccountIdB, Convert.ToInt32(Amount), c);
                                            break;
                                        case "4"://delete account
                                            Console.WriteLine("Plese select an account by entering the accountId: ");
                                            AccountId = Console.ReadLine();
                                            Console.WriteLine("deleteing Account...");
                                            GetAccounts.CloseAccount(c, AccountId);
                                            break;
                                        case "5"://show transaction List
                                            Console.WriteLine($"Fetching Transaction for {c.FirstName} {c.LastName}");
                                            var TrasnactionList = new CustomerBL();
                               
                                            var Dispalylist = TrasnactionList.DispalyTransaction(c.CustomerId);
                                            foreach (var item in Dispalylist)
                                            {
                                                Console.WriteLine($"Account ID{item.AccountIDA} Amount: {item.AmountInTransaction} Time: {item.TransactionTime}");
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                         //           Console.WriteLine("Do you wish to continue? y/n...");
                         //           Continue1 = Console.ReadLine();
                         //}while (Continue1 == "Y"|| Continue == "y");
                                break;
                                
                                
                            default:
                                Console.WriteLine("Thank for using ...");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Thank You For Using Yi's Banking App ");
                        break;
                }
                Console.WriteLine("Do you wish to continue? y/n...");
                Continue = Console.ReadLine();
            } while (Continue == "Y"|| Continue == "y");
         
            
           

        }
    }
}



