using Calculator.Models;

namespace Calculator.Services
{
    public class CommonCalculator : ICommonCalculator
    {
        public CalculatorModel CalculatorModel { get; } = new CalculatorModel();

        public CommonCalculator()
        {
        }
    }
}
