using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        //enum status
        //{
        //    InssuficentBalance = 1,
        //    Success = 2,
        //    fail = 3
        //}
        static int Id = 100;
        static Dictionary<int, string> AllAccounts = new Dictionary<int, string>();
        static List<Checking> Checkingaccounts= new List<Checking>();
        static List<Loan> LoanAccounts = new List<Loan>();
        static List<TermDeposit> TermDepositAccounts= new List<TermDeposit>();
        static List<Business> BusinessAccounts= new List<Business>();
        static List<Transaction> TransactionLog = new List<Transaction>();
        public Accounts CreateAccount(string acccounttype, Customer Cust) {
            switch (acccounttype)
            {
                case "1":
                    var a = new Checking() {
                        AccountId = Id,
                        Balance = 0,
                        CustomerId = Cust.CustomerId,
                        CreationDate = DateTime.Now
                    };
                    Cust.Account.Add(a.AccountId, a.AccountType);
                    Checkingaccounts.Add(a);
                    AllAccounts.Add(a.AccountId, a.AccountType);
                    Id++;
                    return a;
                case "2":
                    var b = new Business()                  
                    {
                        AccountId = Id,
                        Balance = 0,
                        CustomerId = Cust.CustomerId,
                        CreationDate = DateTime.Now
                    };
                    Id++;
                    Cust.Account.Add(b.AccountId, b.AccountType);
                    BusinessAccounts.Add(b);
                    AllAccounts.Add(b.AccountId, b.AccountType);
                    return b;
                case "3":
                    var c = new Loan()
                    {
                        AccountId = Id,
                        Balance = 0,
                        CustomerId = Cust.CustomerId,
                        CreationDate = DateTime.Now
                    };
                    Id++;
                    LoanAccounts.Add(c);
                    Cust.Account.Add(c.AccountId, c.AccountType);

                       AllAccounts.Add(c.AccountId, c.AccountType);
                    return c;
                case "4":
                    var d = new TermDeposit()
                    {
                        AccountId = Id,
                        Balance = 0,
                        CustomerId = Cust.CustomerId,
                        CreationDate = DateTime.Now
                    };
                    Id++; 
                    TermDepositAccounts.Add(d);
                    Cust.Account.Add(d.AccountId, d.AccountType);
                       AllAccounts.Add(d.AccountId, d.AccountType);
                    return d;
                default:
                    Console.WriteLine("Invaild Value Entered");
                    Console.WriteLine("Please enter a number from 1-4");
                    var x = Console.ReadLine();
                    CreateAccount(x, Cust);
                    return null;
            }

        }
        public string AccountType(string AccountID)
        {
            foreach (var items in AllAccounts)
            {
                if (items.Key == Convert.ToInt32(AccountID))
                {
                    return items.Value;
                }
            }
            return "Account Not Found";
        }
        //public Accounts GetAccountsDAL(string AccountType, string AccountID) {
        //    switch (AccountType)
        //    {
        //        case "Checking":
        //            foreach (var A in Checkingaccounts)
        //            {
        //                if (Convert.ToInt32(AccountID) == A.AccountId)
        //                {
        //                    return A;
        //                }
        //            }
        //            break;
        //        case "Loan":
        //            foreach (var B in LoanAccounts)
        //            {
        //                if (Convert.ToInt32(AccountID) == B.AccountId)
        //                {
        //                    return B;
        //                }
        //            }
        //            break;
        //        case "Bussiness":
        //            foreach (var C in BusinessAccounts)
        //            {
        //                if (Convert.ToInt32(AccountID) == C.AccountId)
        //                {
        //                    return C;
        //                }

        //            }
        //            break;
        //        case "TermDeposit":
        //            foreach (var D in TermDepositAccounts)
        //            {
        //                if (Convert.ToInt32(AccountID) == D.AccountId)
        //                {
        //                    return D;
        //                }
        //            }
        //            break;
        //    }
        //    return null;
        //}
        public string CloseAccountDAL(string AccountType, string AccountID, Customer cust) {
         
            
            switch (AccountType)
            {
                case "Checking":
                    foreach (var item in Checkingaccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            var NewTransaction = new Transaction() {
                                AccountIDA = AccountID,
                                TransactionType = "Delete Account" + AccountType,
                                CustomerId = cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString()

                            };
                            TransactionLog.Add(NewTransaction);

                            Checkingaccounts.Remove(item);
                            return "Account Deleted";                           
                        }                     
                    }
               
                    break;
                case "Loan":
                    foreach (var A in LoanAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == A.AccountId)
                        {
                            if (A.Balance >= 0)
                            {
                                var NewTransaction = new Transaction()
                                {
                                    AccountIDA = AccountID,
                                    TransactionType = "Delete Account" + AccountType,
                                    CustomerId = cust.CustomerId,
                                    TransactionTime = DateTime.Now.ToString()

                                };
                                TransactionLog.Add(NewTransaction);
                                LoanAccounts.Remove(A);
                                return "Account Deleted";
                            }
                            else
                            {
                                return "Action Failed: You still owe money in this loan Account!";
                             
                            }

                        }                
                    }
             
                    break;
                case "Bussiness":
                    foreach (var B in BusinessAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == B.AccountId)
                        {
                            var NewTransaction = new Transaction()
                            {
                                AccountIDA = AccountID,
                                TransactionType = "Delete Account" + AccountType,
                                CustomerId = cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString()

                            };
                            TransactionLog.Add(NewTransaction);
                            BusinessAccounts.Remove(B);
                            return "Account Deleted";
                        }

                    }
                                     
                    break;
                case "TermDeposit":
                    foreach (var C in TermDepositAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == C.AccountId)
                        {
                            var NewTransaction = new Transaction()
                            {
                                AccountIDA = AccountID,
                                TransactionType = "Delete Account" + AccountType,
                                CustomerId = cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString()
                            };
                            TransactionLog.Add(NewTransaction);
                            TermDepositAccounts.Remove(C);
                            return "Account Deleted";
                        }                     
                    }                  
                    break;
            }
            return "Account not found";
        }
        public string WithDrawDAL(string AccountType, string AccountID, int Amount, Customer Cust)
        {
            switch (AccountType)
            {
                case "1":
                    foreach (var item in Checkingaccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            if (Amount <= item.Balance)
                            {
                                var NewTransaction = new Transaction()
                                {
                                    AccountIDA = AccountID,
                                    TransactionType = "WithDraw From" + AccountType,
                                    CustomerId = Cust.CustomerId,
                                    TransactionTime = DateTime.Now.ToString(),
                                    AmountInTransaction = Amount

                                };
                                TransactionLog.Add(NewTransaction);
                                item.Balance = item.Balance - Amount;
                            }
                            else
                            {
                                return "Error insufficent balance";
                            }
                        }
                    }                   
                    break;
                case "2":
                    foreach (var item in LoanAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            if (item.Balance - Amount  <= item.LoanLimit)
                            {
                                var NewTransaction = new Transaction()
                                {
                                    AccountIDA = AccountID,
                                    TransactionType = "Loan From" + AccountType,
                                    CustomerId = Cust.CustomerId,
                                    TransactionTime = DateTime.Now.ToString(),
                                    AmountInTransaction = Amount

                                };
                                TransactionLog.Add(NewTransaction);
                                item.Balance = item.Balance - Amount;
                                return "sucess";
                            }
                            else
                            {
                                return "Action Failed:Loan Limit reached!";
                            }

                        }
                    }
                    break;
                case "3":
                    foreach (var item in BusinessAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            if(item.Balance + Amount <= item.Balance + item.Overdraw)
                            {
                                var NewTransaction = new Transaction()
                                {
                                    AccountIDA = AccountID,
                                    TransactionType = "WithDraw From" + AccountType,
                                    CustomerId = Cust.CustomerId,
                                    TransactionTime = DateTime.Now.ToString(),
                                    AmountInTransaction = Amount

                                };
                                TransactionLog.Add(NewTransaction);
                                item.Balance = item.Balance - Amount;
                                return "Sucess";
                            }
                            else
                            {
                                return "Transaction fail: OverDraw Limit Reached";
                            }
                        }

                    }
                    break;
                case "4":
                    foreach (var item in TermDepositAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        
                            if(item.Maturity < DateTime.Now && item.Balance >= Amount)
                            {
                                var NewTransaction = new Transaction()
                                {
                                    AccountIDA = AccountID,
                                    TransactionType = "WithDraw From" + AccountType,
                                    CustomerId = Cust.CustomerId,
                                    TransactionTime = DateTime.Now.ToString(),
                                    AmountInTransaction = Amount

                                };
                                TransactionLog.Add(NewTransaction);
                                item.Balance -= Amount;
                                return "Sucess";
                            }
                            else
                            {
                                return "Maturity Date Not meet!";
                            }
                        }
                    break;
                    }
            return "Failed";
        }
        public string DepositDAL(string AccountType,string AccountID, int Amount, Customer Cust)
        {
            switch (AccountType)
            {
                case "Checking":
                    foreach (var item in Checkingaccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            var NewTransaction = new Transaction()
                            {
                                AccountIDA = AccountID,
                                TransactionType = "Deposit into" + AccountType,
                                CustomerId = Cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString(),
                                AmountInTransaction = Amount

                            };
                            TransactionLog.Add(NewTransaction);
                            item.Balance += Amount;
                            return "Sucess";
    
                        }
                    }
                    break;
                case "Business":
                    foreach (var item in BusinessAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            var NewTransaction = new Transaction()
                            {
                                AccountIDA = AccountID,
                                TransactionType = "Deposit into" + AccountType,
                                CustomerId = Cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString(),
                                AmountInTransaction = Amount

                            };
                            TransactionLog.Add(NewTransaction);
                            item.Balance = item.Balance + Amount;
                                return "Sucess";
                        }
                    }
                    break;
                case "TermDeposit":
                    foreach (var item in TermDepositAccounts)
                    {
                        if (Convert.ToInt32(AccountID) == item.AccountId)
                        {
                            var NewTransaction = new Transaction()
                            {
                                AccountIDA = AccountID,
                                TransactionType = "Deposit into" + AccountType,
                                CustomerId = Cust.CustomerId,
                                TransactionTime = DateTime.Now.ToString(),
                                AmountInTransaction = Amount

                            };
                            TransactionLog.Add(NewTransaction);
                            item.Balance += Amount;
                            item.Maturity = DateTime.Now;
                            return "Sucess";
                        }
                                
                    }
                    break;
            }
            return "Failed";
        }
        public string TransferDAL(string YourAccountID, string accounttypeA, string SecondAccountID, string Acctypeb, int Amount,Customer Cust)
        {

            switch (accounttypeA)
            {
                case "Checking":
                    foreach (var item in Checkingaccounts)
                    {
                        if (Convert.ToInt32(YourAccountID) == item.AccountId)
                        {
                            item.Balance = item.Balance - Amount;
                            switch (Acctypeb)
                            {
                                case "Checking":
                                    foreach (var itema in Checkingaccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == itema.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA +" Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            itema.Balance = itema.Balance + Amount;
                                            break;
                                        }
                                    }
                                    break;
                                case "Bussiness":
                                    foreach (var itemb in BusinessAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance = item.Balance + Amount;
                                            return "Sucess";
                                        }
                                    }
                                    break;
                                case "TermDeposit":
                                    foreach (var itemc in TermDepositAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance += Amount;
                                            return "Sucess";
                                        }

                                    }
                                    break;

                            }
                        }
                        break;
                    }
                    break;
                case "Bussiness":
                    foreach (var item in BusinessAccounts)
                    {
                        if (Convert.ToInt32(YourAccountID) == item.AccountId)
                        {
                            item.Balance = item.Balance - Amount;
                            switch (Acctypeb)
                            {
                                case "Checking":
                                    foreach (var itema in Checkingaccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == itema.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            itema.Balance = itema.Balance + Amount;
                                            return "Sucess";
                                        }
                                    }
                                    break;
                                case "Bussiness":
                                    foreach (var itemb in BusinessAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance = item.Balance + Amount;
                                            return "Sucess";
                                        }
                                    }
                                    break;
                                case "TermDeposit":
                                    foreach (var itemc in TermDepositAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance += Amount;
                                            return "Sucess";
                                        }

                                    }
                                    break;
                            }
                        }
                        break;
                    }
                    break;
                case "TermDeposit":
                    foreach (var item in TermDepositAccounts)
                    {
                        if (Convert.ToInt32(YourAccountID) == item.AccountId)
                        {
                            item.Balance -= Amount;
                            item.Maturity = DateTime.Now;
                            switch (Acctypeb)
                            {
                                case "Checking":
                                    foreach (var itema in Checkingaccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == itema.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            itema.Balance = itema.Balance + Amount;
                                            return "Sucess";
                                        }
                                    }
                                    break;
                                case "Bussiness":
                                    foreach (var itemb in BusinessAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance = item.Balance + Amount;
                                            return "Sucess";
                                        }
                                    }
                                    break;
                                case "TermDeposit":
                                    foreach (var itemc in TermDepositAccounts)
                                    {
                                        if (Convert.ToInt32(SecondAccountID) == item.AccountId)
                                        {
                                            var NewTransaction = new Transaction()
                                            {
                                                AccountIDA = accounttypeA,
                                                TransactionType = accounttypeA + " Transfer to " + Acctypeb,
                                                CustomerId = Cust.CustomerId,
                                                TransactionTime = DateTime.Now.ToString(),
                                                AmountInTransaction = Amount

                                            };
                                            TransactionLog.Add(NewTransaction);
                                            item.Balance += Amount;
                                            return "Sucess";
                                        }

                                    }
                                    break;
                            }
                            break;
                        }
                        break;
                    }
                    break;
            }
            return "Failed";
        }
    
        public string PayLoanInstallementDAL(string AccountId, int Amount,Customer Cust)
        {
            foreach (var item in LoanAccounts) {
                if(item.AccountId == Convert.ToInt32(AccountId))
                {
                    var NewTransaction = new Transaction()
                    {
                        AccountIDA = AccountId,
                        TransactionType = "Pay Loan",
                        CustomerId = Cust.CustomerId,
                        TransactionTime = DateTime.Now.ToString(),
                        AmountInTransaction = Amount

                    };
                    TransactionLog.Add(NewTransaction);
                    item.Balance += Amount; 
                }
            }
            return "Failed";
        }
  
        public List<Transaction> DispalyTransactionDAL(int CustomerId)
        {
            List<Transaction> Temp = new List<Transaction>();
            foreach(var item in TransactionLog)
            {
                if(item.CustomerId == Convert.ToInt32(CustomerId))
                {                   
                    Temp.Add(item);
                }
            }
            return Temp;
        }
    }
}
