using System;
using System.Diagnostics;
using HotelBookingConsoleProject.Application.Service.Dto;
using HotelBookingConsoleProject.Application.Service.Interfaces;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;

class SerializeCommand
{
    private readonly ISerializableService _serializableService;
    
    public SerializeCommand(ISerializableService serializableService)
    {
        _serializableService = serializableService;
    }

    public void Execute()
    {
        var f = F.Get();
        var stopwatch = new Stopwatch();

        // Сериализация с рефлексией
        stopwatch.Start();
        for (int i = 0; i < 1000; i++)
        {
            _serializableService.SerializeWithReflection(f);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на сериализацию с рефлексией: {stopwatch.ElapsedMilliseconds} мс");

        // Десериализация с рефлексией
        var serializedData = _serializableService.SerializeWithReflection(f);
        stopwatch.Restart();
        for (int i = 0; i < 1000; i++)
        {
            _serializableService.DeserializeWithReflection(serializedData);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на десериализацию с рефлексией: {stopwatch.ElapsedMilliseconds} мс");

        // Сериализация с Newtonsoft JSON
        stopwatch.Restart();
        for (int i = 0; i < 1000; i++)
        {
            _serializableService.SerializeWithJson(f);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на сериализацию с Newtonsoft JSON: {stopwatch.ElapsedMilliseconds} мс");

        // Десериализация с Newtonsoft JSON
        var json = _serializableService.SerializeWithJson(f);
        stopwatch.Restart();
        for (int i = 0; i < 1000; i++)
        {
            _serializableService.DeserializeWithJson(json);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на десериализацию с Newtonsoft JSON: {stopwatch.ElapsedMilliseconds} мс");
    }    
}
