using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightClientTest.FlightQueryReference;

namespace FlightClientTest
{
    class FlightQueryCallback: FlightQueryReference.IFlightQueryServiceCallback
    {
        public void OnFlightIDQueryCallback(string[] flights)
        {
            int iNum = 1;
            Console.WriteLine("----- Displaying all the flights operating between the two cities ----- ");
            foreach (string s in flights)
            {
                Console.WriteLine("{0}- {1}", iNum++, s);
            }
            Console.WriteLine(" ------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void onDestinationQueryCallback(FlightQueryReference.DestinationInfo[] destinations)
        {
            Console.WriteLine("-------- Displaying Destination Information from the system -------------- ");
            foreach (FlightQueryReference.DestinationInfo d in destinations)
            {
                Console.WriteLine("{0} is {1}", d.CityCode, d.CityName);
            }
            Console.WriteLine(" ------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void onAvailabilityQueryCallback(bool status)
        {
            if (status)
                Console.WriteLine("Seats are available... Book now. ");
            else
                Console.WriteLine("Seats requested are not available, enquire for another day");
        }

        public void onFlightInfoQueryCallback(FlightQueryReference.FlightInfo[] flights)
        {
            Console.WriteLine("-------- Displaying Flight Information from the system -------------- ");
            foreach (FlightInfo f in flights)
            {
                Console.WriteLine("FlightInfo - {0}", f.ToString());
            }
            Console.WriteLine(" ------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
