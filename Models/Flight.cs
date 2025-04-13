using System.ComponentModel.DataAnnotations;

namespace ApiUppgift.Models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = null!;
    public string Airline { get; set; } = null!;
    public string DepartureCity { get; set; } = null!;
    public string ArrivalCity { get; set; } = null!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public int AvailableSeats { get; set; }
    public string? Gate { get; set; }
    public string? Terminal { get; set; }

    // Navigation properties
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
} 