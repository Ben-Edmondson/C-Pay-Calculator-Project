﻿using Microsoft.AspNetCore.Mvc;
using PayCalc_Class_Library.Repos;
using PayCalc_Project.Models;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository<PermanentEmployee> _permRepo;
        private readonly IEmployeeRepository<TemporaryEmployee> _temporaryRepo;

        public HomeController(IEmployeeRepository<PermanentEmployee> permRepo, IEmployeeRepository<TemporaryEmployee> tempRepo)
        {
            _permRepo = permRepo;
            _temporaryRepo = tempRepo;
        }

        public IActionResult Index()
        {
            HomeViewModel employeeView = new HomeViewModel(_permRepo.ReadAll(), _temporaryRepo.ReadAll());
            return View(employeeView);
        }   
    }
}