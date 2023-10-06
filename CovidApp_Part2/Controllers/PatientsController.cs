using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp_Part2.Data;
using CovidApp_Part2.Models;
using CovidApp_Part2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidApp_Part2.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private IRepositoryWrapper _repository;

        [TempData]
        public string Message { get; set; }
        public int PageSize = 20;

        public PatientsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string sortBy, int PatientsPage = 1)
        {
            ViewData["Message"] = Message;

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "PatientId";
            }

            ViewData["IdSortParam"] = "PatientId";
            ViewData["AgeSortParam"] = "PatientAge";
            ViewData["GenderSortParam"] = "GenderId";

            return View(new PatientsListViewModel
            {
                Patients = _repository.Patient.GetPatientsWithDetails(sortBy)
            .Skip((PatientsPage - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = PatientsPage,
                    PatientsPerPage = PageSize,
                    TotalPatients = _repository.Patient.GetPatientsWithDetails(sortBy).Count()
                }
            });
        }

        public IActionResult AddPatient()
        {
            ViewBag.GenderId = new SelectList(_repository.Gender.FindAll(), "GenderId", "GenderName");
            ViewBag.ProvinceId = new SelectList(_repository.Province.FindAll(), "ProvinceId", "ProvinceName");
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _repository.Patient.Create(patient);
                _repository.Patient.Save();
                TempData["Message"] = $"{patient.PatientId} was added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult PatientDetails(int id)
        {
            ViewData["Message"] = Message;

            ViewBag.CurrentStatus = _repository.PatientStatus.GetCurrentStatusOfPatient(id);

            var PatientDetails = _repository.Patient.GetPatientWithStatusDetails(id);
            if (PatientDetails == null)
            {
                return NotFound();
            }
            return View(PatientDetails);
        }

        [Authorize(Roles = "DataCapturer, Admin")]
        public IActionResult Mark(int id)
        {
            var ps = _repository.PatientStatus.FindAll().OrderBy(ps => ps.PatientStatusDate).ToList()[0];
            ps.StatusId = 2;

            _repository.PatientStatus.Update(ps);
            _repository.PatientStatus.Save();
            return View("PatientDetails", ps.PatientId);
        }
    }
}
