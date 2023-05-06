using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class Celsius2FahrenheitController : Controller
    {
        private readonly ICelsius2FahrenheitConverter _calculator;

        public Celsius2FahrenheitController(ICelsius2FahrenheitConverter calculator)
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
        public IActionResult DoCalculation(Celsius2FahrenheitModel model)
        {
            _calculator.Model.Input = model.Input;
            _calculator.Model.Mode = model.Mode;
            _calculator.DoCalculation();

            return View("Index", _calculator.Model);
        }
    }
}
