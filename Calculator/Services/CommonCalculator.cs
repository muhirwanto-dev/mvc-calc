using System.Data;
using Calculator.Models;

namespace Calculator.Services
{
    public class CommonCalculator : ICommonCalculator
    {
        public CommonCalculatorModel Model { get; } = new CommonCalculatorModel();

        public CommonCalculator()
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
            Model.Expression = string.Empty;
        }

        public void AssignExpression(string value)
        {
            if (value != "." || Model.Expression == null || !Model.Expression.Contains(value))
            {
                Model.Expression += value;
            }
        }

        public void DoCalculation()
        {
            Model.Expression = new DataTable().Compute(Model.Expression, null).ToString() ?? string.Empty;
        }
    }
}
