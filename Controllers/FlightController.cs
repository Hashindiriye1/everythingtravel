using Microsoft.AspNetCore.Mvc;
using ApiUppgift.DTOs;
using ApiUppgift.Services;

namespace ApiUppgift.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlights(
        [FromQuery] string? filter,
        [FromQuery] string? sort)
    {
        var flights = await _flightService.GetAllFlightsAsync(filter, sort);
        return Ok(flights);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FlightDto>> GetFlight(int id)
    {
        var flight = await _flightService.GetFlightByIdAsync(id);
        if (flight == null)
            return NotFound();

        return Ok(flight);
    }

    [HttpPost]
    public async Task<ActionResult<FlightDto>> CreateFlight(CreateFlightDto flightDto)
    {
        var createdFlight = await _flightService.CreateFlightAsync(flightDto);
        return CreatedAtAction(nameof(GetFlight), new { id = createdFlight.Id }, createdFlight);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FlightDto>> UpdateFlight(int id, UpdateFlightDto flightDto)
    {
        var updatedFlight = await _flightService.UpdateFlightAsync(id, flightDto);
        if (updatedFlight == null)
            return NotFound();

        return Ok(updatedFlight);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(int id)
    {
        var result = await _flightService.DeleteFlightAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
} 