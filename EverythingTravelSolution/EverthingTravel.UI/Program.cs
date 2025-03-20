using EverythingTravel.Core.Factories;
using EverythingTravel.Core.Models;
namespace EverthingTravel.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("✈️ Welcome to EverythingTravel Booking System ✈️");

            // Skapa bokningar
            Booking flight = BookingFactory.CreateBooking("flyg", "Paris", new DateTime(2025, 06, 15));
            Booking hotel = BookingFactory.CreateBooking("hotell", "Paris", new DateTime(2025, 06, 15));
            Booking activity = BookingFactory.CreateBooking("aktivitet", "Paris", new DateTime(2025, 06, 16));

            // Bekräfta bokningar
            flight.ConfirmBooking();
            hotel.ConfirmBooking();
            activity.ConfirmBooking();

            Console.WriteLine("\n✅ Bokningar skapade och bekräftade!");
            Console.ReadLine();
        }
    }
}
