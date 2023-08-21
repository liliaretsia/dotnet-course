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

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
class AddHotelCommand
{
    private readonly IAddHotelUseCase _addHotelUseCase;

    public AddHotelCommand(IAddHotelUseCase addHotelUseCase)
    {
        _addHotelUseCase = addHotelUseCase;
    }

    public async Task AddHotelAsync(string name, int hotelTypeId)
    {
        await _addHotelUseCase.ExecuteAsync(name, hotelTypeId);
        Console.WriteLine($"Added hotel with name {name} and type ID {hotelTypeId}.");
    }
}
