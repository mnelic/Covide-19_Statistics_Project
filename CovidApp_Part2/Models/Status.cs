using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Required]
        [DisplayName("Status")]
        public string StatusName { get; set; }

        //Navigation properties
        public ICollection<PatientStatus> PatientStatuses { get; set; }
    }
}
