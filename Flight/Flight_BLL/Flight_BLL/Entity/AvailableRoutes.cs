using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight_DAL;

namespace Flight.BLL.Entity
{
    public class AvailableRoutes : Route
    {
        private DateTime dtFlightDate;

        public DateTime FlightDate
        {
            get { return dtFlightDate; }
            set { dtFlightDate = value; }
        }

    }
}
