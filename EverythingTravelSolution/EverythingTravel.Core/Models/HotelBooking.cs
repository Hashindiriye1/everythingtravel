using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EverythingTravel.Core.Models
{
    public class HotelBooking : Booking
    {
        public override void ConfirmBooking()
        {
            Console.WriteLine($"🏨 Hotellbokning bekräftad i {Destination} från {Date:yyyy-MM-dd}");
        }
    }
}
