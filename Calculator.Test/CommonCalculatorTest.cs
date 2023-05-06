using Calculator.Controllers;
using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Test
{
    public class CommonCalculatorTest : IClassFixture<TestFixture>
    {
        private readonly IServiceProvider _serviceProvider;

        public CommonCalculatorTest(TestFixture testFixture)
        {
            _serviceProvider = testFixture.ServiceProvider;
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("+", "+")]
        [InlineData("3", "3")]
        [InlineData(".", ".")]
        public void AssignExpression_ValidInput_ReturnTrue(string value, string expected)
        {
            using (var calculator = _serviceProvider.GetService<ICommonCalculator>())
            {
                Assert.True(calculator != null, "CommonCalculator doesn't exist");

                var controller = new CommonCalculatorController(calculator);
                var result = controller.AssignExpression(value);
                var model = ((ViewResult)result).Model as CommonCalculatorModel;

                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal(model.Expression, expected);

                controller.ClearExpression();
            }
        }

        [Fact]
        public void ClearExppression_ReturnTrue()
        {
            using (var calculator = _serviceProvider.GetService<ICommonCalculator>())
            {
                Assert.True(calculator != null, "CommonCalculator doesn't exist");
                
                calculator.Model.Expression = "1+4*6/6";

                var controller = new CommonCalculatorController(calculator);
                var result = controller.ClearExpression();
                var model = ((ViewResult)result).Model as CommonCalculatorModel;

                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal(model.Expression, string.Empty);
            }
        }

        [Theory]
        [InlineData("1+4", "5")]
        [InlineData("2*5+3", "13")]
        [InlineData("2.4*2", "4.8")]
        public void DoCalculation_ReturnTrue(string expression, string expected)
        {
            using (var calculator = _serviceProvider.GetService<ICommonCalculator>())
            {
                Assert.True(calculator != null, "CommonCalculator doesn't exist");

                calculator.Model.Expression = expression;

                var controller = new CommonCalculatorController(calculator);
                var result = controller.DoCalculation();
                var model = ((ViewResult)result).Model as CommonCalculatorModel;

                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal(model.Expression, expected);
            }
        }
    }
}