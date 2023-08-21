using HotelBookingConsoleProject.Domain.Model.Entity;
using HotelBookingConsoleProject.Domain.Model.Interfaces;
using HotelBookingConsoleProject.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HotelBookingConsoleProject.Infrastructure.Repository;

public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext _context;

    public HotelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAllHotelsWithRoomsAsync()
    {
        return await _context.Hotel
            .Include(h => h.HotelType)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.RoomType)
            .ToListAsync();
    }

    public async Task AddAsync(Hotel hotel)
    {
        if (hotel == null)
        {
            throw new ArgumentNullException(nameof(hotel));
        }

        await _context.Hotel.AddAsync(hotel);
        await _context.SaveChangesAsync();
    }
}
