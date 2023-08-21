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
using CommandLine;
using HotelBookingConsoleProject.Presentation.ConsoleCommand.Options;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
public static class Startup
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var parserResult = Parser.Default.ParseArguments<FetchDbDataOptions, AddHotelOptions>(args);
        
        await parserResult.MapResult(
            async (FetchDbDataOptions opts) =>
            {
                var program = serviceProvider.GetRequiredService<FetchDbDataCommand>();
                await program.RunAsync();
            },
            async (AddHotelOptions opts) =>
            {
                var command = serviceProvider.GetRequiredService<AddHotelCommand>();

                await command.AddHotelAsync(opts.Name, opts.TypeId);
            },
            errs => Task.CompletedTask // Handle errors
        );
    }

    public static IServiceProvider ConfigureServices()
    {
        var configuration = LoadConfiguration();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        return new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString))
            .RegisterServices()
            .BuildServiceProvider();
    }

    private static IConfiguration LoadConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}