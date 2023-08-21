using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.UseCase.Interfaces;

public interface IAddHotelUseCase
{
    Task ExecuteAsync(string name, int hotelTypeId);
}
