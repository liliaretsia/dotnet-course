using System;
using HotelBookingConsoleProject.Domain.Model.Interfaces;

namespace HotelBookingConsoleProject.Domain.Model.Entity;

public abstract class Vehicle : ICloneable, IMyCloneable<Vehicle>
{
    public abstract Vehicle Clone();
    object ICloneable.Clone() => Clone();
}
