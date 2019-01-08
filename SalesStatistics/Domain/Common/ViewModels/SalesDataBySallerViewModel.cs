using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.Domain.Common.ViewModels
{
    public class SalesDataBySallerViewModel
    {
        public string Seller { get; set; }
        public double Plan { get; set; }
        public double Ammount { get; set; }
        public double AmmountUpToPlan { get; set; }
        public double Percentage { get; set; }
    }
}
