using Microsoft.AspNetCore.Mvc;
using ScenarioSolution;

namespace WebSolution.Controllers
{
    public class SolutionController : controllerBase
    {
        private IEvenCalculator _calculator;

        public SolutionController(IEvenCalculator calculator)
        {
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            base.addHomeToBreadCrumb();
            return View();
        }

        [HttpGet]
        public JsonResult GetResult(int value)
        {
            var result = _calculator.IsEven(value);
            return Json(new { result = result.ToString() });
        }
    }
}