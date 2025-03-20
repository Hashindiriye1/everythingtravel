using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingTravel.Core.Models
{
    public class ActivityBooking : Booking
    {
        public override void ConfirmBooking()
        {
            Console.WriteLine($"🎟 Aktivitet bokad i {Destination} på {Date:yyyy-MM-dd}");
        }
    }
}
