using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using HotelBookingConsoleProject.Domain.Model.Interfaces;
using HotelBookingConsoleProject.Application.UseCase;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using HotelBookingConsoleProject.Infrastructure.Repository;
using HotelBookingConsoleProject.Infrastructure.EntityFramework;
using System;
using System.Threading.Tasks;
using System.IO;
using HotelBookingConsoleProject.Domain.Model.Entity;
using System.Collections.Generic;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
public class FetchDbDataCommand
{
    private readonly IGetAllHotelsWithRoomsUseCase _getAllHotelsWithRoomsUseCase;

    public FetchDbDataCommand(IGetAllHotelsWithRoomsUseCase getAllHotelsWithRoomsUseCase)
    {
        _getAllHotelsWithRoomsUseCase = getAllHotelsWithRoomsUseCase;
    }

    public async Task RunAsync()
    {
        var hotels = await _getAllHotelsWithRoomsUseCase.ExecuteAsync();
        PrintHotelData(hotels);
    }

    private void PrintHotelData(IEnumerable<Hotel> hotels)
    {
        if (hotels == null) return;

        foreach (var hotel in hotels)
        {
            Console.WriteLine($"Hotel Name: {hotel?.Name}, Hotel Type: {hotel?.HotelType?.Name}");
            if (hotel?.Rooms != null)
            {
                foreach (var room in hotel.Rooms)
                {
                    Console.WriteLine($"Room: {room?.Name}, Room Type: {room?.RoomType?.Name}");
                }
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}