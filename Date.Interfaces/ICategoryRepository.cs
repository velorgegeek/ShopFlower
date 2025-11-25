using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace Data.Interfaces
{
    public interface ICategoryRepository
    {
        bool Add(string category);
        List<CategoryProduct> GetAll();

    }
}
