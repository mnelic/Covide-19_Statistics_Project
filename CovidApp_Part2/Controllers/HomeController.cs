using System;
using System.Linq;
using CovidApp_Part2.Data;
using CovidApp_Part2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
 
//using System.Web.Mvc;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidApp_Part2.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repository;
        public HomeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(QueryStatistics());
        }

        public IActionResult History(string searchDate = "")
        {
            return View(QueryStatistics(searchDate));
        }

        private BasicStatsGroupViewModel QueryStatistics(string searchDate = "")
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.Parse(searchDate);
            }
            catch
            {
                dateTime = DateTime.Now;
            }

            int tests = _repository.PatientStatus.FindByCondition(ps =>
                ps.PatientStatusDate <= dateTime).Count();

            int positive = _repository.Test.FindByCondition(t =>
                t.TestResultId == 1 && t.TestDate <= dateTime).Count();

            int recoveries = _repository.PatientStatus.FindByCondition(ps =>
                ps.StatusId == 3 && ps.PatientStatusDate <= dateTime).Count();

            int deaths = _repository.PatientStatus.FindByCondition(ps =>
                ps.StatusId == 2 && ps.PatientStatusDate <= dateTime).Count();

            var stats = new BasicStatsGroupViewModel
            {
                TotalTests = tests,
                TotalPositiveCases = positive,
                TotalRecoveries = recoveries,
                TotalDeaths = deaths
            };

            return stats;
        }
     

    }
}
