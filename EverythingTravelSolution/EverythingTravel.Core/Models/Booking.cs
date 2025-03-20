using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingTravel.Core.Models
{
    public abstract class Booking
    {
        public string Destination { get; set; }
        public DateTime Date { get; set; }

        public abstract void ConfirmBooking();
    }
}
