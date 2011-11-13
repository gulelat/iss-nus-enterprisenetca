using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightClientTest.FlightQueryReference;
using FlightClientTest.FlightBookingReference;
using System.ServiceModel;

namespace FlightClientTest
{
    class FlightTest
    {
        FlightQueryReference.FlightQueryServiceClient proxy;
        FlightBookingReference.FlightBookingServiceClient proxyBooking;

        static void Main(string[] args)
        {
            FlightTest test = new FlightTest();

            test.intialization();

            Console.WriteLine("Requesting list of all destinations");
            //get all the destinations 
            test.proxy.getListOfDestinations();

            //get user inputs
            Console.Write("Enter the starting city code - ");
            string sStart = Console.ReadLine();
            Console.Write("Enter the destination city code - ");
            string sEnd = Console.ReadLine();

            Console.WriteLine("Requesting all the flight IDs between the cities...");
            test.proxy.getAllFlightIDs(sStart, sEnd);

            test.proxy.getListOfAllFlightsBetweenCities(sStart, sEnd);

            test.proxy.getListOfAllAvailableFlightsBetweenCitiesOnDates(sStart, sEnd, DateTime.Now, DateTime.Now.AddDays(2));

            DateTime dtFlight = DateTime.ParseExact("08 Nov 2011 20:00", "dd MMM yyyy HH:mm", null);
            test.proxy.checkIfAvailable(sStart, sEnd, dtFlight, 2);

            Console.WriteLine("Booking tickets now...");

            PassengerInfo[] lstPassengers = test.getPassengers(2).ToArray();
            PaymentInfo pInfo = new PaymentInfo();
            pInfo.cardholdername = lstPassengers[0].passengerName;
            pInfo.cardname = "VISA";
            pInfo.expiryDate = DateTime.Now.AddMonths(2);
            pInfo.cv2 = "234";

            bool bStatus = test.proxyBooking.makeReservation(sStart, sEnd, dtFlight, lstPassengers, pInfo);
            if (bStatus)
                Console.WriteLine("Seats requested have been booked!!!");
            else
                Console.WriteLine("Seats have not been booked!!! Find out why?");

            Console.WriteLine("Press <ENTER> to exit");
            Console.ReadLine();
        }

        private void intialization()
        {
            FlightQueryCallback callback = new FlightQueryCallback();
            InstanceContext context = new InstanceContext(callback);
            proxy = new FlightQueryServiceClient(context);

            proxyBooking = new FlightBookingServiceClient();
        }

        private List<PassengerInfo> getPassengers(int iCount)
        {
            List<PassengerInfo> pList = new List<PassengerInfo>();

            PassengerInfo pInfo;
            for (int i = 0; i < iCount; i++)
            {
                pInfo = new PassengerInfo();
                pInfo.passengerName = "Test" + i;
                pInfo.passportNo = "XYZ" + i + new Random().Next();
                pInfo.expiryDate = DateTime.Now.AddDays(120);
                pList.Add(pInfo);
            }

            return pList;
        }

    }
}
