using EventOne.DTO;
using EventOne.Models;
using EventOne.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventOne.Controllers;


[ApiController]
[Route("[controller]")]
public class DriversController(IDriversService driversService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetDrivers() => Ok(await driversService.GetDrivers());

    [HttpPost]
    public async Task<IActionResult> PostDrivers(CreateDriverDto createDriverDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await driversService.CreateDriver(createDriverDto);

        return StatusCode(201);
    }
}