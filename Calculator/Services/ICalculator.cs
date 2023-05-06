using Calculator.Models;

namespace Calculator.Services
{
    public interface ICalculator : IDisposable
    {
        /// <summary>
        /// Clear all calculator input.
        /// </summary>
        public void ClearExpression();

        /// <summary>
        /// Do the calculation based on the value set.
        /// </summary>
        public void DoCalculation();
    }
}
