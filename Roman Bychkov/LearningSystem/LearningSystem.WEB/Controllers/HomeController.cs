﻿using LearningSystem.DAL;
using LearningSystem.DAL.Interfaces;
using LearningSystem.WEB.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace LearningSystem.WEB.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesService _service;
        public HomeController(ILogger<HomeController> logger, ICoursesService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Active = "courses";
            ViewBag.Context = HttpContext;
            return View(await _service.GetAsync());
        }

        public IActionResult Privacy()
        {
            ViewBag.Active = "privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}