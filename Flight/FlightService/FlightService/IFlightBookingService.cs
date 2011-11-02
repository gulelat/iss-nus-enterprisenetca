using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightService
{
    public interface IFlightBookingService
    {
        bool makeReservation();
        bool checkIfAvailable();

    }
}
