using EventOne.DTO;
using EventOne.Models;

namespace EventOne.Services;

public interface IDriversService
{
    Task<IList<Drivers>> GetDrivers();
    Task CreateDriver(CreateDriverDto createDriverDto);
}