using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreate { get; set; }
        public List<ProductInSale> Products { get; set; }
    }
}
