using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using Data.Interfaces;
namespace Data.InMemory
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private List<Payments> _transactions = new List<Payments>();
        int counter = 0;

        public bool Add(Payments transaction)
        {
            ArgumentNullException.ThrowIfNull(transaction);
            transaction.Id = counter++;
            _transactions.Add(transaction);
            return true;
        }
        public List<Payments> GetAll()
        {
            return _transactions;
        }
    }
}
