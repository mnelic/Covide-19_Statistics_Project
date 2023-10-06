using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp_Part2.Models.ViewModels
{
    public class BasicStatsGroupViewModel
    {
        public DateTime Date { get; set; }
        public int TotalTests { get; set; }
        public int TotalPositiveCases { get; set; }
        public int TotalRecoveries { get; set; }
        public int TotalDeaths { get; set; }
    }
}
