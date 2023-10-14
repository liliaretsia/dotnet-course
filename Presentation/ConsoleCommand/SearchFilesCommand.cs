using System;
using System.IO;
using System.Collections.Generic;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
class SearchFilesCommand
{
    private readonly IFileFinder _fileFinder;

    public SearchFilesCommand(IFileFinder fileFinder)
    {
        _fileFinder = fileFinder;
    }

    public void Execute(string path)
    {
        _fileFinder.FileFound += (sender, args) =>
        {
            Console.WriteLine($"File found: {args.FileName}");
            if (args.FileName.EndsWith(".log"))
            {
                args.CancelRequested = true;
                Console.WriteLine("Log file found. Cancelling further search.");
            }
        };
        _fileFinder.Explore(path);

        var strings = new List<string> { "Short", "VeryVeryLong", "Medium" };
        var longestString = strings.GetMax(s => s.Length);
        Console.WriteLine($"The longest string is: {longestString}");
    }    
}
