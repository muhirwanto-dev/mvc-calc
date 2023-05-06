using System.Data;
using Calculator.Models;

namespace Calculator.Services
{
    public class AreaCalculator : IAreaCalculator
    {
        public AreaCalculatorModel Model { get; } = new AreaCalculatorModel();

        public AreaCalculator()
        {
        }

        #region IDisposable

        public void Dispose()
        {
            // Dummy disposable for unit test
        }

        #endregion // IDisposablse

        public void ClearExpression()
        {
            Model.Result = string.Empty;
            Model.Height = string.Empty;
            Model.Width = string.Empty;
        }

        public void DoCalculation()
        {
            Model.Result = new DataTable().Compute($"{Model.Height} * {Model.Width}", null).ToString() ?? string.Empty;
        }
    }
}
