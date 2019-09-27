using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ScenarioSolution.DTOs;
using ScenarioSolution.Helpers;
using WebSolution.Models;

namespace WebSolution.Controllers
{
    public class HomeController : controllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly IXMLLoader _xmlLoader;

        public HomeController(
            IHostingEnvironment env,
            IXMLLoader xmlLoader
        )
        {
            _env = env;
            _xmlLoader = xmlLoader;
        }

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

        [Route("XML")]
        public IActionResult XML()
        {
            ViewBag.Title = "XML";
            addHomeToBreadCrumb();
            var filename = "static.xml";
            var pathandfile = $"{_env.WebRootPath}\\assets\\xml\\{filename}";
            var model = _xmlLoader.LoadDocumentFromFile<Container>(pathandfile);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
