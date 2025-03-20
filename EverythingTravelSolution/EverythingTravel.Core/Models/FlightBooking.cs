using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingTravel.Core.Models
{
    public class FlightBooking : Booking
    {
        public override void ConfirmBooking()
        {
            Console.WriteLine($"✈️ Flygbokning bekräftad till {Destination} på {Date:yyyy-MM-dd}");
        }
    }
}
