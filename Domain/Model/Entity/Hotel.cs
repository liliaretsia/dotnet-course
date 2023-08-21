using System.Collections.Generic;

namespace HotelBookingConsoleProject.Domain.Model.Entity;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HotelTypeId { get; set; } 
    public HotelType HotelType { get; set; } = null!;
    public List<Room> Rooms { get; set; } = new List<Room>();
}