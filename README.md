# NetCore CLI

Basic structure for a .NET Core command line application that explores the use of  ```Microsoft.Extensions.CommandLineUtils``` package.


## Project Structure


    |-- Program.cs                  (app configuration through DI and startup)
    |-- CliApp.cs                   (main app entry point)
    |-- ...
    |-- Commands
    	|-- ICommand.cs
        |-- SampleCommand.cs        (implementation of a dummy command)
        |-- ...

