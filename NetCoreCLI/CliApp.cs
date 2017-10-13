using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace NetCoreCLI
{
    public class CliApp : CommandLineApplication
    {
        public CliApp()
        {
            Name = "";
            FullName = "";

            HelpOption("-?|-h|--help");
        }
    }
}
