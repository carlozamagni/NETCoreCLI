using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCoreCLI.Commands;

namespace NetCoreCLI
{
    public class Program
    {
        private static IServiceCollection _serviceCollection;

        private static void Configure()
        {
            _serviceCollection = new ServiceCollection();

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            _serviceCollection.AddTransient<ICommand, SampleCommand>();

        }

        public static void Main(string[] args)
        {
            Configure();

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            var app = new CommandLineApplication {Name = "MyCLI"};

            app.HelpOption("-h|--help");

            app.OnExecute(() =>
            {
                Console.WriteLine("Hello World!");
                return 0;
            });

            var sampleCommand = new SampleCommand();

            app.Command(sampleCommand.CommandName, sampleCommand.CommandImplementation);

            app.Execute(args);
        }
    }
}


