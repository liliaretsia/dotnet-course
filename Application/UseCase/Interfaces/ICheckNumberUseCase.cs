using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.UseCase.Interfaces;

public interface ICheckNumberUseCase
{
    public string Execute(int input, int number);
}
