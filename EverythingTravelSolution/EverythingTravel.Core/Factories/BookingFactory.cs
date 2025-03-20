using EverythingTravel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingTravel.Core.Factories
{
    public static class BookingFactory
    {
        public static Booking CreateBooking(string type, string destination, DateTime date)
        {
            return type.ToLower() switch
            {
                "flyg" => new FlightBooking { Destination = destination, Date = date },
                "hotell" => new HotelBooking { Destination = destination, Date = date },
                "transport" => new TransportBooking { Destination = destination, Date = date },
                "aktivitet" => new ActivityBooking { Destination = destination, Date = date },
                _ => throw new ArgumentException("❌ Ogiltig bokningstyp")
            };
        }
    }
}
