using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public record SaleFilter
    {
        public static SaleFilter Empty => new();

        public DateTime? StartDate{ get; set; }
        public DateTime? EndDate{ get; set; }
    }
}
