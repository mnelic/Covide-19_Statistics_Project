using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp_Part2.Models
{
    public class PagingInfo
    {
        public int TotalPatients { get; set; }
        public int PatientsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalPatients / PatientsPerPage);
    }
}
