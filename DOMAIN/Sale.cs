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
        public User User { get; set; }
        public DateTime DateCreate { get; set; }
        public List<ProductInSale> Products { get; set; }
        public int amount
        {
            get
            {
                int i = 0;
                foreach (var q in Products)
                {
                    i += q.ProductVariation.Price * q.Quantity;
                }
                return i;
            }
        }
        public int CountProducts
        {
            get
            {
                int i = 0;
                foreach (var q in Products)
                {
                    i += q.Quantity;
                }
                return i;
            }
        }

        public Sale(int userid,int id,List<ProductInSale> products)
        {
            UserId = userid;    
            Id = id;
            DateCreate = DateTime.Now;
            Products = products;
        }
        public Sale() {
            Products = new List<ProductInSale>();
        }
    }
}
