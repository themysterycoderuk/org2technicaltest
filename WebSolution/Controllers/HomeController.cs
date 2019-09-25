using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebSolution.Models;

namespace WebSolution.Controllers
{
    public class HomeController : controllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Approach")]
        public IActionResult Approach()
        {
            ViewBag.Title = "Approach";
            addHomeToBreadCrumb();
            return View();
        }

        [Route("Implementation")]
        public IActionResult Implementation()
        {
            ViewBag.Title = "Implementation";
            addHomeToBreadCrumb();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
