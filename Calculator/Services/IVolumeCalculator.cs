using Calculator.Models;

namespace Calculator.Services
{
    public interface IVolumeCalculator : ICalculator
    {
        VolumeCalculatorModel Model { get; }
    }
}
