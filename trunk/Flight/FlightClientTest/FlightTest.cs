using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightClientTest.FlightQueryReference;
using System.ServiceModel;

namespace FlightClientTest
{
    class FlightTest
    {
        FlightQueryReference.FlightQueryServiceClient proxy;

        static void Main(string[] args)
        {
            FlightTest test = new FlightTest();

            test.intialization();
            //get all the destinations 
            test.proxy.getListOfDestinations();

            //get user inputs
            Console.Write("Enter the starting city code - ");
            string sStart = Console.ReadLine();
            Console.Write("Enter the destination city code - ");
            string sEnd = Console.ReadLine();

            test.proxy.getAllFlightIDs(sStart, sEnd);

            test.proxy.getListOfAllFlightsBetweenCities(sStart, sEnd);

            Console.WriteLine("Press <ENTER> to exit");
            Console.ReadLine();
        }

        private void intialization()
        {
            FlightQueryCallback callback = new FlightQueryCallback();
            InstanceContext context = new InstanceContext(callback);
            proxy = new FlightQueryServiceClient(context);
        }

    }
}
