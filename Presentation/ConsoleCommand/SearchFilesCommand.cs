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
        List<string> filenames = new();
        
        _fileFinder.FileFound += (sender, args) =>
        {
            Console.WriteLine($"File found: {args.FileName}");
            if (args.FileName.EndsWith(".log"))
            {
                args.CancelRequested = true;
                Console.WriteLine("Log file found. Cancelling further search.");
            }

            filenames.Add(args.FileName); 
        };
        _fileFinder.Explore(path);

        var longestString = filenames.GetMax(s => s.Length);
        Console.WriteLine($"The longest string is: {longestString}");
    }    
}
