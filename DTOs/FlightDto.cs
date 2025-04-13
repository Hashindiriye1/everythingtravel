namespace ApiUppgift.DTOs;

public class FlightDto
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
}

public class CreateFlightDto
{
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
}

public class UpdateFlightDto
{
    public string? FlightNumber { get; set; }
    public string? Airline { get; set; }
    public string? DepartureCity { get; set; }
    public string? ArrivalCity { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public decimal? Price { get; set; }
    public int? AvailableSeats { get; set; }
    public string? Gate { get; set; }
    public string? Terminal { get; set; }
} 