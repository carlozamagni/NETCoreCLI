using System;
using Microsoft.Extensions.CommandLineUtils;

namespace NetCoreCLI.Commands
{
    public interface ICommand
    {
        string CommandName { get; }

        Action<CommandLineApplication> CommandImplementation { get; }
    }
}
