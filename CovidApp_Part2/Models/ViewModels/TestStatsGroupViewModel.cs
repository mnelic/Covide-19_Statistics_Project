using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp_Part2.Models.ViewModels
{
    public class TestStatsGroupViewModel
    {
        public DateTime Date { get; set; }
        public int TotalTests { get; set; }
        public int TotalPrivateLabTests { get; set; }
        public int TotalPublicLabTests { get; set; }
        public int TotalPositiveTests { get; set; }
        public int TotalNegativeTests { get; set; }

        public double PrivateLabTestsRate()
        {
            return (TotalPrivateLabTests * 1.0) / TotalTests * 100;
        }
        public double PublicLabTestsRate()
        {
            return (TotalPublicLabTests * 1.0) / TotalTests * 100;
        }
        public double PositiveTestsRate()
        {
            return (TotalPositiveTests * 1.0) / TotalTests * 100;
        }
        public double NegativeTestsRate()
        {
            return (TotalNegativeTests * 1.0) / TotalTests * 100;
        }
    }
}
