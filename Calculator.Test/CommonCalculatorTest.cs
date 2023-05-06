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

                Assert.Equal(expected, model.Expression);

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

                Assert.Equal(string.Empty, model.Expression);
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

                Assert.Equal(expected, model.Expression);

                controller.ClearExpression();
            }
        }

        [Fact]
        public void IntegrationTest_AddExpressions_And_Calculate_Then_Clear_Return_Success()
        {
            using (var calculator = _serviceProvider.GetService<ICommonCalculator>())
            {
                Assert.True(calculator != null, "CommonCalculator doesn't exist");

                var controller = new CommonCalculatorController(calculator);

                // Assign 2 expected 2
                var result = controller.AssignExpression("2");

                var model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2", model.Expression);

                // Assign + expected 2+
                result = controller.AssignExpression("+");

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2+", model.Expression);

                // Assign 4 expected 2+4
                result = controller.AssignExpression("4");

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2+4", model.Expression);

                // Assign . expected 2+4.
                result = controller.AssignExpression(".");

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2+4.", model.Expression);

                // Assign 6 expected 2+4.6
                result = controller.AssignExpression("6");

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2+4.6", model.Expression);

                // Assign . (again) expected 2+4.6
                result = controller.AssignExpression(".");

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("2+4.6", model.Expression);

                // Do calculation expected 6.6
                result = controller.DoCalculation();

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal("6.6", model.Expression);

                // Clear expression expected ''
                result = controller.ClearExpression();

                model = ((ViewResult)result).Model as CommonCalculatorModel;
                if (model == null)
                {
                    Assert.Fail("Invalid model type");
                }

                Assert.Equal(string.Empty, model.Expression);
            }
        }
    }
}