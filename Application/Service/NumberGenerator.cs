using System;
using HotelBookingConsoleProject.Application.Service.Interfaces;

namespace HotelBookingConsoleProject.Application.Service;

public class NumberGenerator : INumberGenerator
{
    private Random _random = new Random();
    public int GenerateNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}
