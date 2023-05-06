using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CommonCalculatorController : Controller
    {
        private readonly ICommonCalculator _calculator;

        public CommonCalculatorController(ICommonCalculator calculator)
        {
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View(_calculator.Model);
        }

        [HttpGet]
        public IActionResult ClearExpression()
        {
            _calculator.ClearExpression();

            return View("Index", _calculator.Model);
        }

        public IActionResult AssignExpression(string value)
        {
            _calculator.AssignExpression(value);

            return View("Index", _calculator.Model);
        }

        [HttpGet]
        public IActionResult DoCalculation()
        {
            _calculator.DoCalculation();

            return View("Index", _calculator.Model);
        }
    }
}
