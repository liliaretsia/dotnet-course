namespace HotelBookingConsoleProject.Domain.Model.Entity;

using System;
public class Bicycle : ICloneable
{
    public string Model { get; set; }
    public int GearCount { get; set; }

    public Bicycle(string model, int gearCount)
    {
        Model = model;
        GearCount = gearCount;
    }

    public object Clone()
    {
        return new Bicycle(Model, GearCount);
    }
}
