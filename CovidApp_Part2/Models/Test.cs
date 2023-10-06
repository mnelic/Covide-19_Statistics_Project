using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class Test
    {
        public int TestId { get; set; }

        [Required]
        public DateTime TestDate { get; set; }

        [Required]
        [DisplayName("Patient ID")]
        public int PatientId { get; set; }

        [Required]
        [DisplayName("Laboratory")]
        public int LabId { get; set; }

        [Required]
        [DisplayName("Test Result")]
        public int TestResultId { get; set; }


        //Navigation properties
        public Patient Patient { get; set; }
        public Lab Lab { get; set; }
        public TestResult TestResult { get; set; }
    }
}
