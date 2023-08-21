using HotelBookingConsoleProject.Domain.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Application.UseCase.Interfaces;

public interface IGetAllHotelsWithRoomsUseCase
{
    Task<List<Hotel>> ExecuteAsync();
}