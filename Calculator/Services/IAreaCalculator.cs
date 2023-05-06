using Calculator.Models;

namespace Calculator.Services
{
    public interface IAreaCalculator : ICalculator
    {
        AreaCalculatorModel Model { get; }
    }
}
