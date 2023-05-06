using Calculator.Models;

namespace Calculator.Services
{
    public interface ICommonCalculator : ICalculator
    {
        CommonCalculatorModel Model { get; }

        /// <summary>
        /// Assign a value to the <see cref="CommonCalculatorModel.Expression"/>.
        /// </summary>
        /// <param name="value">Number or operator as a string</param>
        public void AssignExpression(string value);
    }
}
