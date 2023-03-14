using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Reservation
    {
        public DateTime DateReservation { get; set; }

        public Seat Seat { get; set; }
        public Passenger Passenger { get; set; }

    }
}
