using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Patient
    {
        [DisplayName("Patient ID")]
        public int PatientId { get; set; }

        [Required]
        [DisplayName("Age")]
        [Range(0,100, ErrorMessage ="Age value must be from 0 to 100")]
        public int PatientAge { get; set; }

        [Required]
        [DisplayName("Gender")]
        public int GenderId { get; set; }

        [Required]
        [DisplayName("Province")]
        public int ProvinceId { get; set; }


        //Navigation properties
        public Gender Gender { get; set; }
        public Province Province { get; set; }
        public ICollection<PatientStatus> PatientStatuses { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
