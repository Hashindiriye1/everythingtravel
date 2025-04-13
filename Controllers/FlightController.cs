using Microsoft.AspNetCore.Mvc;
using ApiUppgift.DTOs;
using ApiUppgift.Services;

namespace ApiUppgift.Controllers;

/// <summary>
/// Controller for managing flight operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    /// <summary>
    /// Get all flights with optional filtering and sorting
    /// </summary>
    /// <param name="filter">Optional filter string to search flights</param>
    /// <param name="sort">Optional sorting parameter (e.g. "price", "date")</param>
    /// <returns>List of flights matching the criteria</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlights(
        [FromQuery] string? filter,
        [FromQuery] string? sort)
    {
        var flights = await _flightService.GetAllFlightsAsync(filter, sort);
        return Ok(flights);
    }

    /// <summary>
    /// Get a specific flight by ID
    /// </summary>
    /// <param name="id">The ID of the flight to retrieve</param>
    /// <returns>The requested flight if found</returns>
    /// <response code="200">Returns the requested flight</response>
    /// <response code="404">If the flight is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightDto>> GetFlight(int id)
    {
        var flight = await _flightService.GetFlightByIdAsync(id);
        if (flight == null)
            return NotFound();

        return Ok(flight);
    }

    /// <summary>
    /// Create a new flight
    /// </summary>
    /// <param name="flightDto">The flight details</param>
    /// <returns>The created flight</returns>
    /// <response code="201">Returns the newly created flight</response>
    /// <response code="400">If the flight data is invalid</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightDto>> CreateFlight(CreateFlightDto flightDto)
    {
        var createdFlight = await _flightService.CreateFlightAsync(flightDto);
        return CreatedAtAction(nameof(GetFlight), new { id = createdFlight.Id }, createdFlight);
    }

    /// <summary>
    /// Update an existing flight
    /// </summary>
    /// <param name="id">The ID of the flight to update</param>
    /// <param name="flightDto">The updated flight details</param>
    /// <returns>The updated flight</returns>
    /// <response code="200">Returns the updated flight</response>
    /// <response code="404">If the flight is not found</response>
    /// <response code="400">If the flight data is invalid</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightDto>> UpdateFlight(int id, UpdateFlightDto flightDto)
    {
        var updatedFlight = await _flightService.UpdateFlightAsync(id, flightDto);
        if (updatedFlight == null)
            return NotFound();

        return Ok(updatedFlight);
    }

    /// <summary>
    /// Delete a flight
    /// </summary>
    /// <param name="id">The ID of the flight to delete</param>
    /// <returns>No content if successful</returns>
    /// <response code="204">If the flight was successfully deleted</response>
    /// <response code="404">If the flight is not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFlight(int id)
    {
        var result = await _flightService.DeleteFlightAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
} 