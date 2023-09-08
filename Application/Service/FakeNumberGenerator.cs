using System;
using HotelBookingConsoleProject.Application.Service.Interfaces;

namespace HotelBookingConsoleProject.Application.Service;

public class FakeNumberGenerator : INumberGenerator
{
    public int GenerateNumber(int min, int max)
    {
        return 5;
    }
}
