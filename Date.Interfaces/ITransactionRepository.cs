using DOMAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPaymentsRepository
    {
        bool Add(Payments trans);
        List<Payments> GetAll();

    }
}
