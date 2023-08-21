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

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IHotelRepository, HotelRepository>()
            .AddScoped<IGetAllHotelsWithRoomsUseCase, GetAllHotelsWithRoomsUseCase>()
            .AddScoped<IAddHotelUseCase, AddHotelUseCase>()
            .AddScoped<AddHotelCommand>()
            .AddScoped<FetchDbDataCommand>();
    }
}