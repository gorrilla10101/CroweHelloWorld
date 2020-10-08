using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HelloWorldLibrary;
using Microsoft.Extensions.Options;
using System.Linq;

namespace HelloWorldConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = InitializeDependencyInjection();

            var helloWorldWriter = provider.GetService<IHelloWorldWriter>();
            helloWorldWriter.Write();
        }

        static IConfiguration InitializeConfiguration()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config;
        }

        static IServiceProvider InitializeDependencyInjection()
        {
            var configuration = InitializeConfiguration();
            var services = new ServiceCollection();
            services.Configure<HelloWorldWriterOptions>(configuration.GetSection(nameof(HelloWorldWriterOptions)));
            services.AddTransient<IHelloWorldWriter>(p =>
            {
                var opts = p.GetService<IOptions<HelloWorldWriterOptions>>();
                return new HelloWorldWriterConsole(p.GetRequiredService<IOptions<HelloWorldWriterOptions>>().Value);
            });
            return services.BuildServiceProvider();
        }
    }
}
