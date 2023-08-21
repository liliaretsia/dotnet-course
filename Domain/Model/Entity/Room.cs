namespace HotelBookingConsoleProject.Domain.Model.Entity;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int RoomTypeId { get; set; } 
    public RoomType? RoomType { get; set; }
    public int HotelId { get; set; } 
    public Hotel? Hotel { get; set; }
}