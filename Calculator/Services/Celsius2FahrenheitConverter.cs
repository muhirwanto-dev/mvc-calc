using System.Data;
using Calculator.Models;

namespace Calculator.Services
{
    public enum ConverterMode
    {
        Celsius2Fahrenheit,
        Fahrenheit2Celsius
    }

    public class Celsius2FahrenheitConverter : ICelsius2FahrenheitConverter
    {
        public Celsius2FahrenheitModel Model { get; } = new Celsius2FahrenheitModel();

        public Celsius2FahrenheitConverter()
        {
        }

        public void ClearExpression()
        {
            Model.Input = string.Empty;
            Model.Output = string.Empty;
        }

        public void DoCalculation()
        {
            if (Model.Mode == ConverterMode.Celsius2Fahrenheit)
            {
                Model.Output = new DataTable().Compute($"({Model.Input} * 9 / 5) + 32", null).ToString() ?? string.Empty;
            }
            else
            {
                Model.Output = new DataTable().Compute($"({Model.Input} - 32) * 5 / 9", null).ToString() ?? string.Empty;
            }
        }
    }
}
