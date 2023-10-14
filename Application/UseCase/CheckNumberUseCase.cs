using HotelBookingConsoleProject.Application.UseCase.Interfaces;

namespace HotelBookingConsoleProject.Application.UseCase;

public class CheckNumberUseCase : ICheckNumberUseCase
{
    public string Execute(int input, int number)
    {
        string message;
        if (number == input)
        {
            message = "Поздравляем! Вы отгадали число.";
        } else if (number > input) {
            message = "Загаданное число больше.";
        } else {
            message = "Загаданное число меньше.";
        }

        return message;
    }
}
