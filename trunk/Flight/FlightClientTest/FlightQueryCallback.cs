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
                Console.WriteLine("RouteID - {0} => FlightName: {1}, StartCity: {2}({3}), Destination: {4}({5}), Departure Time: {6}, Rate(A/C): {7}/{8}, NumSeats: {9}",
                    f.ID, f.FlightName, f.StartCity, f.StartCode, 
                    f.Destination, f.DestinationCode, f.DepartureTime.ToString("dd mmm YYYY HH:MM"), 
                    f.AdultRate, f.ChildRate, f.NumSeats);
            }
            Console.WriteLine(" ------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
