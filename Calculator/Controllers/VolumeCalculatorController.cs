using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class VolumeCalculatorController : Controller
    {
        private readonly IVolumeCalculator _calculator;

        public VolumeCalculatorController(IVolumeCalculator calculator)
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
        public IActionResult DoCalculation(VolumeCalculatorModel model)
        {
            _calculator.Model.Height = model.Height;
            _calculator.Model.Width = model.Width;
            _calculator.Model.Wide = model.Wide;
            _calculator.DoCalculation();

            return View("Index", _calculator.Model);
        }
    }
}
