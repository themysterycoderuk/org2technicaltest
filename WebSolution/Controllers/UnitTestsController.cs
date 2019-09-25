using Microsoft.AspNetCore.Mvc;
using TestRunner;

namespace WebSolution.Controllers
{
    public class UnitTestsController : controllerBase
    {
        private IUtilities _utilities;

        public UnitTestsController(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public IActionResult Index()
        {
            base.addHomeToBreadCrumb();

            // Get list of unit tests
            var model = _utilities.FindTests();
            return View(model);
        }

        [HttpGet]
        public JsonResult RunTest(string testName)
        {
            var result = _utilities.RunTest(testName);
            return Json(new { testName = testName, result = result });
        }
    }
}