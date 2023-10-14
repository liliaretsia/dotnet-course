using HotelBookingConsoleProject.Domain.Model.Entity;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using HotelBookingConsoleProject.Domain.Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.UseCase;

public class AddHotelUseCase : IAddHotelUseCase
{
    private readonly IHotelRepository _hotelRepository;

    public AddHotelUseCase(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task ExecuteAsync(string name, int hotelTypeId)
    {
        var hotel = new Hotel { Name = name, HotelTypeId = hotelTypeId };
        await _hotelRepository.AddAsync(hotel);
    }
}