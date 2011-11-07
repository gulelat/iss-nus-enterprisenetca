using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight.BLL
{
    public class FlightBLLFacade
    {
        private IFlightBLL flightBLL;

        public FlightBLLFacade()
        {
            flightBLL = new FlightBLL();
        }

        public IFlightBLL getFlightBLLInstance()
        {
           return flightBLL; 
        }
    }
}
