using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using System;
using System.IO;
using HotelBookingConsoleProject.Application.Event;


namespace HotelBookingConsoleProject.Application.UseCase;

public class FileFinder : IFileFinder
{
    public event EventHandler<FileArgs> FileFound;

    public void Explore(string directoryPath)
    {
        ExploreDirectory(new DirectoryInfo(directoryPath));
    }

    private void ExploreDirectory(DirectoryInfo directory)
    {
        foreach (var file in directory.GetFiles())
        {
            var args = new FileArgs(file.FullName);
            FileFound?.Invoke(this, args);
            if (args.CancelRequested) return;
        }

        foreach (var subDirectory in directory.GetDirectories())
        {
            ExploreDirectory(subDirectory);
        }
    }
}