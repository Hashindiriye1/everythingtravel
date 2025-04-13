using System.ComponentModel.DataAnnotations;

namespace ApiUppgift.Models;

public class Booking
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime BookingDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = null!;

    // Navigation properties
    public int? FlightId { get; set; }
    public Flight? Flight { get; set; }

    public int? HotelId { get; set; }
    public Hotel? Hotel { get; set; }

    public int? TransportId { get; set; }
    public Transport? Transport { get; set; }

    public ICollection<Room>? Rooms { get; set; }
} 