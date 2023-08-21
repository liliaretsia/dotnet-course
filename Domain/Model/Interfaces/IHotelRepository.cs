using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using HotelBookingConsoleProject.Domain.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Domain.Model.Interfaces;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAllHotelsWithRoomsAsync();

    Task AddAsync(Hotel hotel);
}