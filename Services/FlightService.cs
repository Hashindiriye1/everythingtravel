using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiUppgift.Data;
using ApiUppgift.DTOs;
using ApiUppgift.Models;

namespace ApiUppgift.Services;

public interface IFlightService
{
    Task<IEnumerable<FlightDto>> GetAllFlightsAsync(string? filter = null, string? sort = null);
    Task<FlightDto?> GetFlightByIdAsync(int id);
    Task<FlightDto> CreateFlightAsync(CreateFlightDto flightDto);
    Task<FlightDto?> UpdateFlightAsync(int id, UpdateFlightDto flightDto);
    Task<bool> DeleteFlightAsync(int id);
}

public class FlightService : IFlightService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public FlightService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FlightDto>> GetAllFlightsAsync(string? filter = null, string? sort = null)
    {
        var query = _context.Flights.AsQueryable();

        // Apply filtering
        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(f =>
                f.FlightNumber.Contains(filter) ||
                f.Airline.Contains(filter) ||
                f.DepartureCity.Contains(filter) ||
                f.ArrivalCity.Contains(filter));
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(sort))
        {
            query = sort.ToLower() switch
            {
                "price_asc" => query.OrderBy(f => f.Price),
                "price_desc" => query.OrderByDescending(f => f.Price),
                "departure_asc" => query.OrderBy(f => f.DepartureTime),
                "departure_desc" => query.OrderByDescending(f => f.DepartureTime),
                _ => query.OrderBy(f => f.DepartureTime)
            };
        }
        else
        {
            query = query.OrderBy(f => f.DepartureTime);
        }

        var flights = await query.ToListAsync();
        return _mapper.Map<IEnumerable<FlightDto>>(flights);
    }

    public async Task<FlightDto?> GetFlightByIdAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        return flight != null ? _mapper.Map<FlightDto>(flight) : null;
    }

    public async Task<FlightDto> CreateFlightAsync(CreateFlightDto flightDto)
    {
        var flight = _mapper.Map<Flight>(flightDto);
        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task<FlightDto?> UpdateFlightAsync(int id, UpdateFlightDto flightDto)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
            return null;

        _mapper.Map(flightDto, flight);
        await _context.SaveChangesAsync();
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task<bool> DeleteFlightAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
            return false;

        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();
        return true;
    }
} 