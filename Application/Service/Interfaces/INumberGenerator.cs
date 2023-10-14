using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.Service.Interfaces;

public interface INumberGenerator
{
    int GenerateNumber(int min, int max);
}
