using Microsoft.Extensions.DependencyInjection;
using HotelBookingConsoleProject.Domain.Model.Interfaces;
using HotelBookingConsoleProject.Application.UseCase;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;
using HotelBookingConsoleProject.Infrastructure.Repository;
using HotelBookingConsoleProject.Application.Service;
using HotelBookingConsoleProject.Application.Service.Interfaces;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IHotelRepository, HotelRepository>()
            .AddScoped<IGetAllHotelsWithRoomsUseCase, GetAllHotelsWithRoomsUseCase>()
            .AddScoped<INumberGenerator, NumberGenerator>()
            .AddScoped<ICheckNumberUseCase, CheckNumberUseCase>()
            .AddScoped<IAddHotelUseCase, AddHotelUseCase>()
            .AddScoped<IFileFinder, FileFinder>()
            .AddScoped<GenerateNumberCommand>()
            .AddScoped<AddHotelCommand>()
            .AddScoped<CountIntegersCommand>()
            .AddScoped<FetchDbDataCommand>()
            .AddScoped<SearchFilesCommand>();
    }
}