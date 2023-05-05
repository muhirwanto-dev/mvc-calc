using Calculator.Models;

namespace Calculator.Services
{
    public interface ICommonCalculator : ICalculator
    {
        CommonCalculatorModel Model { get; }

        public void AssignExpression(string value);
    }
}
