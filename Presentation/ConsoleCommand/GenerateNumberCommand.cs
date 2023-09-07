using System;
using Microsoft.Extensions.Options;
using HotelBookingConsoleProject.Application.Service.Interfaces;
using HotelBookingConsoleProject.Application.UseCase.Interfaces;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;
class GenerateNumberCommand
{
    private readonly CustomSettingsConfiguration _config;
    private readonly ICheckNumberUseCase _checkNumberUseCase;
    private readonly INumberGenerator _numberGenerator;
    private int _attempt = 0;


    public GenerateNumberCommand(ICheckNumberUseCase checkNumberUseCase, INumberGenerator numberGenerator, IOptions<CustomSettingsConfiguration> config)
    {
        _checkNumberUseCase = checkNumberUseCase;
        _numberGenerator = numberGenerator;
        _config = config.Value;
    }

    public void Execute()
    {
        int maxAttemptNumber = _config.MaxAttemptNumber;
        int number = _numberGenerator.GenerateNumber(1, 100);
        Console.WriteLine(number);

        while (true)
        {
            _attempt++;
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());

            var message = _checkNumberUseCase.Execute(input, number);

            if (_attempt == maxAttemptNumber)
            {
                Console.WriteLine("Это последняя попытка");
                Console.WriteLine(message);
                break;
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }    
}
