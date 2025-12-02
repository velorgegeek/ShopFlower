using DOMAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        bool Add(Transaction trans);
        List<Transaction> GetAll();

    }
}
