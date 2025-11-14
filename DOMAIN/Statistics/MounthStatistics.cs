using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Statistics
{
    public record MouthStatistics
    {
        public required int Year { get; set; }
        public required int Month { get; set; }
        public required int count { get; set; }
        public  string GetMouthName()
        {
            var date = new DateTime(Year, Month, 1);
            return date.ToString("MMM yyyy");
        }
    }
}
