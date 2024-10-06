using AutoMapper;
using EventOne.Data;
using EventOne.DTO;
using EventOne.Models;
using Microsoft.EntityFrameworkCore;

namespace EventOne.Services;

internal class DriversService(AppDbContext dbContext, IMapper mapper, ILogger<DriversService> logger) : IDriversService
{
    public async Task CreateDriver(CreateDriverDto createDriverDto)
    {
        try
        {
            var driver = mapper.Map<Drivers>(createDriverDto);

            dbContext.Drivers.Add(driver);

            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
    }

    public async Task<IList<Drivers>> GetDrivers() =>
     await dbContext.Drivers.ToListAsync();
}