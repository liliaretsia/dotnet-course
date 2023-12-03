using System;
using HotelBookingConsoleProject.Domain.Model.Interfaces;

namespace HotelBookingConsoleProject.Domain.Model.Entity;

public class Truck : Car
{
    public int LoadCapacity { get; set; }

    public Truck(string brand, string model, int year, int loadCapacity)
        : base(brand, model, year)
    {
        LoadCapacity = loadCapacity;
    }

    public override Vehicle Clone()
    {
        return new Truck(Brand, Model, Year, LoadCapacity);
    }
}

