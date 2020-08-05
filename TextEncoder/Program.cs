using TextEncoder.Interface;
using TextEncoder.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TextEncoder
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();

        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITextEncoder, Services.TextEncoder>();
            services.AddSingleton<ConsoleApplication>();            
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
