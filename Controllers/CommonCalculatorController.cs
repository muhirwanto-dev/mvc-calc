using System.Data;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CommonCalculatorController : Controller
    {
        private readonly ICommonCalculator _commonCalculator;

        public CommonCalculatorController(ICommonCalculator commonCalculator)
        {
            _commonCalculator = commonCalculator;
        }

        public IActionResult Index()
        {
            return View(_commonCalculator.CalculatorModel);
        }

        [HttpGet]
        public IActionResult ClearExpression()
        {
            _commonCalculator.CalculatorModel.Expression = string.Empty;

            return View("Index", _commonCalculator.CalculatorModel);
        }

        [HttpGet]
        public IActionResult AssignExpression(string value)
        {
            if (value != "." || !_commonCalculator.CalculatorModel.Expression.Contains(value))
            {
                _commonCalculator.CalculatorModel.Expression += value;
            }

            return View("Index", _commonCalculator.CalculatorModel);
        }

        [HttpGet]
        public IActionResult DoCalculation()
        {
            _commonCalculator.CalculatorModel.Expression = new DataTable().Compute(_commonCalculator.CalculatorModel.Expression, null).ToString() ?? string.Empty;

            return View("Index", _commonCalculator.CalculatorModel);
        }
    }
}
