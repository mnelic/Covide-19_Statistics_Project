using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidApp_Part2.Models
{
    public class TestResult
    {
        public int TestResultId { get; set; }

        [Required]
        [DisplayName("Test result")]
        public string TestResultName { get; set; }

        //Navigation properties
        public ICollection<Test> Tests { get; set; }
    }
}
