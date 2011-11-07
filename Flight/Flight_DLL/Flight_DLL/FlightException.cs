using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight_DAL
{
    public class FlightException : Exception
    {
        public FlightException()
        {
        }

        public FlightException(string message)
            : base(message)
        {
        }
    }
}
