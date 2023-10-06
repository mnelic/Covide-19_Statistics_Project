using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp_Part2.Data;
using CovidApp_Part2.Models;
using CovidApp_Part2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidApp_Part2.Controllers
{
    public class TestsController : Controller
    {
        private IRepositoryWrapper _repository;

        public TestsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            TestStatsGroupViewModel data = new TestStatsGroupViewModel
            {
                Date = DateTime.Now,
                TotalTests = _repository.Test.FindAll().Count(),
                TotalPrivateLabTests = _repository.Test.FindByCondition(l => l.LabId == 1).Count(),
                TotalPublicLabTests = _repository.Test.FindByCondition(l => l.LabId == 2).Count(),
                TotalPositiveTests = _repository.Test.FindByCondition(tr => tr.TestResultId == 1).Count(),
                TotalNegativeTests = _repository.Test.FindByCondition(tr => tr.TestResultId == 2).Count()
            };
            if (data == null)
            {
                return View();
            }
            else
            {
                return View(data);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PatientId = new SelectList(_repository.Patient.FindAll(), "PatientId", "PatientId");
            ViewBag.LabId = new SelectList(_repository.Lab.FindAll(), "LabId", "LabName");
            ViewBag.TestResultId = new SelectList(_repository.TestResult.FindAll(), "TestResultId", "TestResultName");
            return View();
        }

        public IActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                int currentStatus = _repository.PatientStatus.GetCurrentStatusOfPatient(test.PatientId);

                if(currentStatus != 2)
                {
                    _repository.Test.Create(test);
                    _repository.Test.Save();

                    int resultId = test.TestResultId;

                    PatientStatus patientStatus = new PatientStatus();
                    patientStatus.PatientStatusDate = DateTime.Now;
                    patientStatus.PatientId = test.PatientId;

                    if(currentStatus == 0 || currentStatus == 4)
                        if (resultId == 1)
                            patientStatus.StatusId = 1;
                        else
                            patientStatus.StatusId = 4;
                    else if(currentStatus == 1)
                        if (resultId == 1)
                            patientStatus.StatusId = 1;
                        else
                            patientStatus.StatusId = 3;
                    else
                        if (resultId == 1)
                        patientStatus.StatusId = 1;
                    else
                        patientStatus.StatusId = 3;

                    _repository.PatientStatus.Create(patientStatus);
                    _repository.PatientStatus.Save();
                }

                return View("Completed", _repository.Patient.GetPatientWithStatusDetails(test.PatientId));
            }
            return View();
        }

        public IActionResult Completed(Patient patient)
        {
            return View(patient);
        }
    }
}
