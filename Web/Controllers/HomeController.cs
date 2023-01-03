﻿using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
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
            HomeViewModel employeeView = new HomeViewModel(_permRepo.ReadAll());
            return View(employeeView);
        }   

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PermanentEmployee()
        {
            PermanentEmployeeViewModel permView = new PermanentEmployeeViewModel(_permRepo.ReadAll());
            return View(permView);
        }

        public IActionResult TemporaryEmployees()
        {
            TemporaryEmployeeViewModel tempView = new TemporaryEmployeeViewModel(_temporaryRepo.ReadAll());
            return View(tempView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}