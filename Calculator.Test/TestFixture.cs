using Calculator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Test
{
    public class TestFixture
    {
        public ServiceProvider ServiceProvider { get; }

        public TestFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ICommonCalculator, CommonCalculator>();
            serviceCollection.AddSingleton<IAreaCalculator, AreaCalculator>();
            serviceCollection.AddSingleton<IVolumeCalculator, VolumeCalculator>();
            serviceCollection.AddSingleton<ICelsius2FahrenheitConverter, Celsius2FahrenheitConverter>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
