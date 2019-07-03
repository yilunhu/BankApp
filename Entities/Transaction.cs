using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Transaction
    {
        public int CustomerId;
        public string TransactionTime; //DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        public string AccountIDA;//Account that initalize the transaction.
        public int AmountInTransaction;
        public string AccountIDB; //reciever
        public string TransactionType;
        
    }
}
