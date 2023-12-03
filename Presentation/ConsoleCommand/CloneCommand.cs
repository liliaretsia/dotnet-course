using System;
using HotelBookingConsoleProject.Domain.Model.Entity;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;

class CloneCommand
{
    public void Execute()
    {
        Bicycle originalBike = new Bicycle("MountainBike", 21);
        Bicycle clonedBike = (Bicycle)originalBike.Clone();

        Console.WriteLine($"Original Bike: Model = {originalBike.Model}, Gears = {originalBike.GearCount}");
        Console.WriteLine($"Cloned Bike: Model = {clonedBike.Model}, Gears = {clonedBike.GearCount}");
        
        Car originalCar = new Car("Toyota", "Corolla", 2020);
        Car clonedCar = (Car)originalCar.Clone();

        Console.WriteLine("Original Car: Brand = {0}, Model = {1}, Year = {2}", originalCar.Brand, originalCar.Model, originalCar.Year);
        Console.WriteLine("Cloned Car: Brand = {0}, Model = {1}, Year = {2}", clonedCar.Brand, clonedCar.Model, clonedCar.Year);

        Truck originalTruck = new Truck("Volvo", "FH", 2018, 10000);
        Truck clonedTruck = (Truck)originalTruck.Clone();

        Console.WriteLine("Original Truck: Brand = {0}, Model = {1}, Year = {2}, Load Capacity = {3}kg", originalTruck.Brand, originalTruck.Model, originalTruck.Year, originalTruck.LoadCapacity);
        Console.WriteLine("Cloned Truck: Brand = {0}, Model = {1}, Year = {2}, Load Capacity = {3}kg", clonedTruck.Brand, clonedTruck.Model, clonedTruck.Year, clonedTruck.LoadCapacity);
    }    
}
