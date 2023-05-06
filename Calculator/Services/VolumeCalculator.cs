using System.Data;
using Calculator.Models;

namespace Calculator.Services
{
    public class VolumeCalculator : IVolumeCalculator
    {
        public VolumeCalculatorModel Model { get; } = new VolumeCalculatorModel();

        public VolumeCalculator()
        {
        }

        public void ClearExpression()
        {
            Model.Result = string.Empty;
            Model.Height = string.Empty;
            Model.Width = string.Empty;
            Model.Wide = string.Empty;
        }

        public void DoCalculation()
        {
            Model.Result = new DataTable().Compute($"{Model.Height} * {Model.Width} * {Model.Wide}", null).ToString() ?? string.Empty;
        }
    }
}
