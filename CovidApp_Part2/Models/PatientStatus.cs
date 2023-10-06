using System;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class PatientStatus
    {
        public int PatientStatusId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public DateTime PatientStatusDate { get; set; }

        //Navigation properties
        public Patient Patient { get; set; }
        public Status Status { get; set; }
    }
}
