using Calculator.Models;

namespace Calculator.Services
{
    public interface ICelsius2FahrenheitConverter : ICalculator
    {
        Celsius2FahrenheitModel Model { get; }
    }
}
