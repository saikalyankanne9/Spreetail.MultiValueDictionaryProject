using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Spreetail.MultiValueDictionary.Services.Implementation.v1;
using Spreetail.MultiValueDictionary.Services.Interfaces.v1;
using System;

namespace Spreetail.MultiValueDictionary
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<Initializer>().Run();
            DisposeServices();
        }
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient(typeof(IMultiValueDictionary<,>), typeof(MultiValueDictionaryImpl<,>));
            services.AddSingleton<Initializer>();
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
