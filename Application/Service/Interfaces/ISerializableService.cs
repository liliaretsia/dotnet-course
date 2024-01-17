using System.Threading.Tasks;
using HotelBookingConsoleProject.Application.Service.Dto;

namespace HotelBookingConsoleProject.Application.Service.Interfaces;

public interface ISerializableService
{
    string SerializeWithReflection(F obj);

    F DeserializeWithReflection(string data);

    string SerializeWithJson(F obj);

    F DeserializeWithJson(string data);
}
