using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace NetCoreCLI.Commands
{
    public class SampleCommand : ICommand
    {
        private ILogger<SampleCommand> _logger;

        public string CommandName => "sample";

        public Action<CommandLineApplication> CommandImplementation
        {
            get
            {
                return cmd =>
                {
                    cmd.Name = CommandName;
                    cmd.Description = "a sample command, it does nothing.";
                    cmd.HelpOption("-h|--help|--h");

                    var samples = cmd.Option(
                        "-s|--samples <samples>",
                        "samples to printout",
                        CommandOptionType.MultipleValue);

                    var verbose = cmd.Option(
                        "-v|--verbose",
                        "verbosity",
                        CommandOptionType.NoValue);

                    cmd.OnExecute(() =>
                    {
                        if (verbose.HasValue())
                        {
                            samples.Values.ForEach(s =>
                            {
                                var when = DateTime.UtcNow;
                                Console.WriteLine($"{when} - {cmd.Name} - {s}");
                            });
                        }
                        else
                        {
                            samples.Values.ForEach(Console.WriteLine);
                        }

                        return 0;
                    });
                };
            }
        }

        public SampleCommand(ILogger<SampleCommand> logger)
        {
            _logger = logger;
        }
    }
}
