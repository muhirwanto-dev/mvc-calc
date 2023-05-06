using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class AreaCalculatorController : Controller
    {
        private readonly IAreaCalculator _calculator;

        public AreaCalculatorController(IAreaCalculator calculator)
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

        [HttpGet]
        public IActionResult DoCalculation(AreaCalculatorModel model)
        {
            _calculator.Model.Height = model.Height;
            _calculator.Model.Width = model.Width;
            _calculator.DoCalculation();

            return View("Index", _calculator.Model);
        }
    }
}
