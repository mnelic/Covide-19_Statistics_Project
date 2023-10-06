using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Gender
    {
        public int GenderId { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string GenderName { get; set; }

        //Navigation properties
        public ICollection<Patient> Patients { get; set; }
    }
}
