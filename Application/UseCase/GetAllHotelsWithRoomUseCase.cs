using HotelBookingConsoleProject.Domain.Model.Entity;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using HotelBookingConsoleProject.Domain.Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.UseCase;

public class GetAllHotelsWithRoomsUseCase : IGetAllHotelsWithRoomsUseCase
{
    private readonly IHotelRepository _hotelRepository;

    public GetAllHotelsWithRoomsUseCase(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<List<Hotel>> ExecuteAsync()
    {
        return await _hotelRepository.GetAllHotelsWithRoomsAsync();
    }
}