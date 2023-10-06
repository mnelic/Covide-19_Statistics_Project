using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Lab
    {
        [DisplayName("Laboratory")]
        public int LabId { get; set; }

        [Required]
        [DisplayName("Laboratory name")]
        public string LabName { get; set; }

        //Navigation properties
        public ICollection<Test> Tests { get; set; }

    }
}
