﻿using KNdatabase.Data;
using KNdatabase.Models.Domain;
using KNdatabase.Models.Repository;
using KNdatabase.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KNdatabase.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        // GET: /Student/GetAll
        [Route("/Student/GetAll")]
        public IActionResult GetAll(string? searchString, string? type)
        {
            var allStudent = _studentRepository.GetAll(searchString, type);
            return View(allStudent);
        }

        // GET: /Student/GetStudentById/id
        public IActionResult GetStudentById(int id)
        {
            var studentById = _studentRepository.GetStudentsById(id);
            if (studentById != null)
                return View(studentById);
            else
                return View("NotFound");
        }
        [Authorize(Roles = "Admin,Editor")]
        // GET: /Student/EditStudentById/id
        [HttpGet]
        public IActionResult EditStudentById(int id)
        {
            var studentVM = _studentRepository.GetStudentsById(id);
            if (studentVM != null)
                return View(studentVM);
            else
                return View("NotFound");
        }
        [Authorize(Roles = "Admin,Editor")]
        // POST: /Student/EditStudentById/id
        [HttpPost]
        public IActionResult EditStudentById([FromRoute] int id, VMStudent student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentById = _studentRepository.GetStudentsById(id);
                    if (studentById != null)
                    {
                        _studentRepository.UpdateStudentById(id, student);
                        TempData["successMessage"] = "Successful";
                        return RedirectToAction("GetAll");
                    }
                    else
                    {
                        return View("NotFound");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [Authorize(Roles = "Admin,Editor")]
        // GET: /Student/AddStudent
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Editor")]
        // POST: /Student/AddStudent
        [HttpPost]
        public IActionResult AddStudent(VMStudent studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.AddStudent(studentData);
                    TempData["successMessage"] = "Successful";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    TempData["errorMessage"] = "Data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [Authorize(Roles = "Admin,Editor")]
        // GET: /Student/DelStudentById/id
        public IActionResult DelStudentById(int id)
        {
            var studentById = _studentRepository.GetStudentsById(id);
            if (studentById != null)
            {
                _studentRepository.DeleteStudentById(id);
                TempData["successMessage"] = "Deleted";
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("NotFound");
            }
        }
    }
}
