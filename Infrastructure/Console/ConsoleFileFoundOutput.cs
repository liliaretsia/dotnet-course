using System;
using HotelBookingConsoleProject.Domain.Model.Interfaces;

namespace HotelBookingConsoleProject.Infrastructure.Repository;

public class ConsoleFileFoundOutput : IConsoleFileFoundOutput
{
    public void HandleFileFound(string filePath)
    {
        Console.WriteLine($"File found: {filePath}");
    }
}

