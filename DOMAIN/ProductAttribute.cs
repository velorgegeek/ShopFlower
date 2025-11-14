using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class ProductAttribute
    {
        public int? ID { get; set; }
        public int? ProductVariationID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
