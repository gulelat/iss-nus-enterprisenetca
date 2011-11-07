using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight.BLL;
using Flight_DAL;
using Flight.BLL.Entity;

namespace TestBLL
{
    class TestBAL
    {
        static void Main(string[] args)
        {

            TestBAL myInstance = new TestBAL();

            FlightBLLFacade bll = new FlightBLLFacade();

            IFlightBLL flightBLL = bll.getFlightBLLInstance();
            //get all the flights operating between two cities
            myInstance.listAllFlights(flightBLL, "SIN", "BLR");

            //list all the destinations
            DateTime dtFlight = DateTime.Now;
            myInstance.listDestinations(flightBLL);

            //get user inputs
            Console.Write("Enter the starting city code - ");
            string sStart = Console.ReadLine();
            Console.Write("Enter the destination city code - ");
            string sEnd = Console.ReadLine();
            myInstance.listRoutesBetweenCities(flightBLL, sStart, sEnd);

            Console.Write("Enter the number of days starting from today ({0}) for which you want to check schedule ", dtFlight.ToShortDateString());
            int iNumDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of passengers travelling - ");
            int iPassenger = Convert.ToInt32(Console.ReadLine());
            myInstance.listAvailableRoutesBetweenCitiesOnDates(flightBLL, "SIN", "BLR", dtFlight, dtFlight.AddDays(iNumDays), iPassenger);

            Console.Write("Enter the correct date of flight (in format dd mmm yyyy) - ");
            string sDateFlight = Console.ReadLine();
            dtFlight = DateTime.Parse(sDateFlight);
            Console.Write("Enter the route ID - ");
            int iRouteID = Convert.ToInt32(Console.ReadLine());
            //generate a list of passengers to be reserved on the flight
            string sBookingRef = myInstance.makeReservation(flightBLL, iRouteID, dtFlight, myInstance.getListOfPassengers(flightBLL, iPassenger));

           
            Console.WriteLine("Press <ENTER> to exit");
            Console.ReadLine();
        }

        private void listAllFlights(IFlightBLL flightBLL, string start, string end)
        {
             List<Route> lst = flightBLL.getFlightsBetweenCities(start, end);
             if (lst != null)
             {
                 var fl = (from r in lst
                           select r.Flight.FlightID).Distinct();
                 if (fl != null)
                 {
                     foreach (string s in fl.ToArray())
                     {
                         Console.WriteLine(s);
                     }
                 }
             }
             else
             {
                 Console.WriteLine("No flights found");
             }
        }

        private void listDestinations(IFlightBLL flightBLL)
        {
            List<Destination> lstDest = flightBLL.getAllDestinations();
            if (lstDest != null)
            {
                Console.WriteLine("------ Listing all the destinations ----- ");
                foreach (Destination d in lstDest)
                {
                    Console.WriteLine(d.City + " is " + d.CityCode);
                }
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Destinations in the database !!!");
            }
        }

        private void listRoutesBetweenCities(IFlightBLL flightBLL, string start, string end)
        {
            List<Route> lst = flightBLL.getFlightsBetweenCities(start, end);
            if (lst != null)
            {
                Console.WriteLine("------ Listing routes between " + start + " and " + end + " ----- ");
                foreach (Route d in lst)
                {
                    Console.WriteLine(d.RouteID + " - Starts From - " + d.StartCity + ", Ends At - " + d.EndCity + ", Time - " + d.FlightTime + ", Adult/Child Fare - " + d.AdultFare + "/" + d.ChildFare);
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Routes in the database !!!");
            }
        }

        private void listAvailableRoutesBetweenCitiesOnDates(IFlightBLL flightBLL, string start, string end, DateTime dtStart, DateTime dtEnd, int numSeats)
        {
 /*           List<Route> lst = flightBLL.getAvailableFlightBetweenCitiesOnDates(start, end, dtStart, dtEnd, numSeats);
            if (lst != null)
            {
                Console.WriteLine("------ Listing routes between " + start + " and " + end + " ----- ");
                foreach (Route d in lst)
                {
                    Console.WriteLine("{0} - Starts From - {1}, Ends at - {2}, Departure Time - {3}, Fare(A/C) - ${4} / ${5}",
                        d.RouteID, d.StartCity, d.EndCity, d.FlightTime, d.AdultFare, d.ChildFare); 
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Routes in the database !!!");
            }*/
        }

        private string makeReservation(IFlightBLL flightBLL, int iRouteID, DateTime dtFlight, List<Passenger> lstPassengers)
        {
            try
            {
                string s= flightBLL.reserveFlight(iRouteID, dtFlight, lstPassengers);
                Console.WriteLine("Flight reserved - Reservation Reference - {0}", s);

                //Make Payment
                PaymentDetails p = new PaymentDetails();
                p.CardName = "UOB Visa";
                p.CardHolderName = lstPassengers.FirstOrDefault().PassengerName;
                p.CardExpiryDate = dtFlight.AddDays(60);
                p.Cv2 = "039";
                flightBLL.makePayment(s, p);               

                return s;
            }
            catch (FlightException fe)
            {
                Console.WriteLine(fe.Message);
            }
            return "N/A";
        }

        private List<Passenger> getListOfPassengers(IFlightBLL flightBLL, int iNum)
        {
            List<Passenger> lstPassenger = new List<Passenger>();
            for (int i = 0; i < iNum; i++)
            {
                Passenger p = new Passenger();
                p.PassengerName = "Temp" + i;
                p.PassportNo = generateReservationID(6).ToUpper();
                p.ExpiryDate = DateTime.Now.AddDays(150);
                lstPassenger.Add(p);
            }
            return lstPassenger;
        }

        private static readonly Random _random = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string _nums = "1234567890";
        private string generateReservationID(int iLen)
        {
            char[] buffer = new char[iLen];

            for (int i = 0; i < iLen; i++)
            {
                buffer[i] = _chars[_random.Next(_chars.Length)];
                buffer[++i] = _nums[_random.Next(_nums.Length)];
            }
            return new string(buffer);
        }
    }
}
