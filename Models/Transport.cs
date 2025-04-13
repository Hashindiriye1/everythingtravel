using System.ComponentModel.DataAnnotations;

namespace ApiUppgift.Models;

public class Transport
{
    public int Id { get; set; }
    public string Type { get; set; } = null!; // e.g., Taxi, Bus, Train
    public string Provider { get; set; } = null!;
    public string FromLocation { get; set; } = null!;
    public string ToLocation { get; set; } = null!;
    public DateTime DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }

    // Navigation properties
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
} 