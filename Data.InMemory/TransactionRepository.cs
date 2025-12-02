using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using Data.Interfaces;
namespace Data.InMemory
{
    public class TransactionRepository  : ITransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();
        int counter = 0;

        public bool Add(Transaction transaction)
        {
            ArgumentNullException.ThrowIfNull(transaction);
            transaction.Id = counter++;
            _transactions.Add(transaction);
            return true;
        }
        public List<Transaction> GetAll()
        {
            return _transactions;
        }
    }
}
