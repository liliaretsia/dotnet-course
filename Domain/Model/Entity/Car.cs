using System;
using HotelBookingConsoleProject.Domain.Model.Interfaces;

namespace HotelBookingConsoleProject.Domain.Model.Entity;

public class Car : Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public override Vehicle Clone()
    {
        return new Car(Brand, Model, Year);
    }
}

