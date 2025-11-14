using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Statistics
{
    public record ProductStaticsItem
    {
        public required string ProductName { get; set; }
        public required int Count { get; set; }
    }
}
