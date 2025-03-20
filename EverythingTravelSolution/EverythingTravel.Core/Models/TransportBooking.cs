using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EverythingTravel.Core.Models
{
    public class TransportBooking : Booking
    {
        public override void ConfirmBooking()
        {
            Console.WriteLine($"🚗 Transport bokad i {Destination} på {Date:yyyy-MM-dd}");
        }
    }
}
