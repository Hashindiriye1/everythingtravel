using System.ComponentModel.DataAnnotations;

namespace ApiUppgift.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string Type { get; set; } = null!; // e.g., Single, Double, Suite
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }

    // Navigation properties
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
} 