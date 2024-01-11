using System;

namespace HotelBookingConsoleProject.Application.Event;

public class FileArgs : EventArgs
{
    public string FileName { get; }
    public bool CancelRequested { get; set; }
    public FileArgs(string fileName) => FileName = fileName;
}