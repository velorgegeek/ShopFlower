using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class CategoryProduct
    {
        public int IdCategory {  get; set; }
        public string Name { get; set; }
        public CategoryProduct(int idCategory, string name )
        {
            IdCategory = idCategory;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
