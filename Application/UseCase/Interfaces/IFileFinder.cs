using HotelBookingConsoleProject.Application.Event;
using System;

namespace HotelBookingConsoleProject.Application.UseCase.Interfaces;

public interface IFileFinder
{
    event EventHandler<FileArgs> FileFound;
    void Explore(string directoryPath);
}
