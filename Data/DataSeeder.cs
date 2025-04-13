using Bogus;
using ApiUppgift.Models;

namespace ApiUppgift.Data;

public static class DataSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        if (context.Flights.Any() || context.Hotels.Any() || context.Transports.Any())
            return;

        var faker = new Faker();

        // Generate Flights
        var flightFaker = new Faker<Flight>()
            .RuleFor(f => f.FlightNumber, f => f.Random.AlphaNumeric(6).ToUpper())
            .RuleFor(f => f.Airline, f => f.Company.CompanyName())
            .RuleFor(f => f.DepartureCity, f => f.Address.City())
            .RuleFor(f => f.ArrivalCity, f => f.Address.City())
            .RuleFor(f => f.DepartureTime, f => f.Date.Future(1))
            .RuleFor(f => f.ArrivalTime, (f, flight) => flight.DepartureTime.AddHours(f.Random.Number(1, 12)))
            .RuleFor(f => f.Price, f => f.Random.Decimal(500, 5000))
            .RuleFor(f => f.AvailableSeats, f => f.Random.Number(0, 200))
            .RuleFor(f => f.Gate, f => f.Random.AlphaNumeric(3).ToUpper())
            .RuleFor(f => f.Terminal, f => f.Random.Number(1, 5).ToString());

        var flights = flightFaker.Generate(50);
        context.Flights.AddRange(flights);

        // Generate Hotels
        var hotelFaker = new Faker<Hotel>()
            .RuleFor(h => h.Name, f => f.Company.CompanyName() + " Hotel")
            .RuleFor(h => h.City, f => f.Address.City())
            .RuleFor(h => h.Country, f => f.Address.Country())
            .RuleFor(h => h.Address, f => f.Address.FullAddress())
            .RuleFor(h => h.Description, f => f.Lorem.Paragraph())
            .RuleFor(h => h.StarRating, f => f.Random.Number(1, 5))
            .RuleFor(h => h.PricePerNight, f => f.Random.Decimal(500, 5000))
            .RuleFor(h => h.HasWifi, f => f.Random.Bool())
            .RuleFor(h => h.HasParking, f => f.Random.Bool())
            .RuleFor(h => h.HasPool, f => f.Random.Bool())
            .RuleFor(h => h.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(h => h.Email, f => f.Internet.Email());

        var hotels = hotelFaker.Generate(30);
        context.Hotels.AddRange(hotels);

        // Generate Transports
        var transportFaker = new Faker<Transport>()
            .RuleFor(t => t.Type, f => f.PickRandom("Taxi", "Bus", "Train", "Shuttle"))
            .RuleFor(t => t.Provider, f => f.Company.CompanyName())
            .RuleFor(t => t.FromLocation, f => f.Address.City())
            .RuleFor(t => t.ToLocation, f => f.Address.City())
            .RuleFor(t => t.DepartureTime, f => f.Date.Future(1))
            .RuleFor(t => t.ArrivalTime, (f, transport) => transport.DepartureTime.AddHours(f.Random.Number(1, 4)))
            .RuleFor(t => t.Price, f => f.Random.Decimal(50, 500))
            .RuleFor(t => t.Capacity, f => f.Random.Number(4, 50))
            .RuleFor(t => t.IsAvailable, f => f.Random.Bool())
            .RuleFor(t => t.Description, f => f.Lorem.Sentence());

        var transports = transportFaker.Generate(40);
        context.Transports.AddRange(transports);

        // Save changes
        context.SaveChanges();

        // Generate Rooms for each hotel
        foreach (var hotel in hotels)
        {
            var roomFaker = new Faker<Room>()
                .RuleFor(r => r.RoomNumber, f => f.Random.Number(100, 999).ToString())
                .RuleFor(r => r.Type, f => f.PickRandom("Single", "Double", "Suite", "Deluxe"))
                .RuleFor(r => r.PricePerNight, (f, r) => hotel.PricePerNight * f.Random.Decimal(0.8m, 2.0m))
                .RuleFor(r => r.Capacity, f => f.Random.Number(1, 4))
                .RuleFor(r => r.IsAvailable, f => f.Random.Bool())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence())
                .RuleFor(r => r.HotelId, f => hotel.Id);

            var rooms = roomFaker.Generate(faker.Random.Number(5, 20));
            context.Rooms.AddRange(rooms);
        }

        // Save all changes
        context.SaveChanges();
    }
} 