using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }

        [Required]
        [DisplayName("Province Name")]
        public string ProvinceName { get; set; }

        [Required]
        [DisplayName("Province abbreviation")]
        [StringLength(3, ErrorMessage = "Abbreviation cannot be longer than three characters")]
        public string ProvinceAbbreviation { get; set; }

        //Navigation properties
        public ICollection<Patient> Patients { get; set; }
    }
}
