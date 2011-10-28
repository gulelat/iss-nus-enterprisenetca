using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Flight_DAL;

namespace TestDAL
{
    public class TestDAL
    {
        public static void Main(String[] arg)
        {

            TestDAL td = new TestDAL();

            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();

            td.saveDestination(flightDAL);
            td.listDestinations(flightDAL);

            td.saveFlights(flightDAL);
            td.listFlights(flightDAL);
            td.listFlight(flightDAL, "2");

            //td.saveRoute(flightDAL);
            td.listAllRoutes(flightDAL);
            td.listRoute(flightDAL, 0);
            td.listRoutesBetweenCities(flightDAL, "BLR", "SIN");

            //create the date of flight
            DateTime dtFlight = DateTime.Now.AddDays(2);

            td.checkAvailability(flightDAL, 0, 2, dtFlight);
            td.checkAvailability(flightDAL, 0, 100, dtFlight);
//            td.saveReservation(flightDAL);
            td.listAllReservations(flightDAL);
             
            Console.WriteLine("Press <ENTER> key to exit");
            Console.ReadLine();
        }

        private void saveDestination(FlightDAOFactory flightDAL)
        {
            try
            {
                //Add destination
                Destination d = new Destination();
                d.CityCode = "BLR";
                d.City = "Bangaluru";
                flightDAL.getFlightDALInstance().saveDestination(d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void listDestinations(FlightDAOFactory flightDAL)
        {
            List<Destination> lstDest = flightDAL.getFlightDALInstance().getAllDestinations();
            if (lstDest != null)
            {
                Console.WriteLine("------ Listing all the destinations ----- ");
                foreach (Destination d in lstDest)
                {
                    Console.WriteLine(d.City + " is " + d.CityCode);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Destinations in the database !!!");
            }
        }

        private void saveFlights(FlightDAOFactory flightDAL)
        {
        }

        private void listFlights(FlightDAOFactory flightDAL)
        {
            List<Flight> lstDest = flightDAL.getFlightDALInstance().getAllFlightDetails();
            if (lstDest != null)
            {
                Console.WriteLine("------ Listing all the flights ----- ");
                foreach (Flight d in lstDest)
                {
                    Console.WriteLine(d.FlightID + " capacity is " + d.Capacity);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Flights in the database !!!");
            }
        }

        private void listFlight(FlightDAOFactory flightDAL, string fID)
        {
            Flight f = flightDAL.getFlightDALInstance().getFlightDetails(fID);
            Console.WriteLine("------ Details of Flight ----- ");
            Console.WriteLine(f.FlightID + " capacity is " + f.Capacity);
            Console.WriteLine("\n");
        }

        private void saveRoute(FlightDAOFactory flightDAL)
        {
            try
            {
                Route r = new Route();
                r.RouteID = flightDAL.getFlightDALInstance().getNextRouteID();
                r.FlightTime = "09:15";
                r.FlightID = "2";
                r.EndCity = "SIN";
                r.StartCity = "BLR";
                r.AdultFare = (float)254.00;
                r.ChildFare = (float)120.00;
                //r.Reservations = null;
                flightDAL.getFlightDALInstance().saveRoute(r);
            }
            catch (FlightException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void listAllRoutes(FlightDAOFactory flightDAL)
        {
            List<Route> lst = flightDAL.getFlightDALInstance().getAllRoutes();
            if (lst != null)
            {
                Console.WriteLine("------ Listing all the routes ----- ");
                foreach (Route d in lst)
                {
                    Console.WriteLine(d.RouteID + " - Starts From - " + d.StartCity + ", Ends At - " + d.EndCity + ", Time - " + d.FlightTime + ", Adult/Child Fare - " + d.AdultFare + "/" + d.ChildFare);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Routes in the database !!!");
            }
        }

        private void listRoute(FlightDAOFactory flightDAL, int iRouteID)
        {
            Route d = flightDAL.getFlightDALInstance().getRouteDetails(iRouteID);
            Console.WriteLine("------- Route Details for id - " + iRouteID +" -------");
            Console.WriteLine(d.RouteID + " - Starts From - " + d.StartCity + ", Ends At - " + d.EndCity + ", Time - " + d.FlightTime + ", Adult/Child Fare - " + d.AdultFare + "/" + d.ChildFare);
            Console.WriteLine();
        }

        private void listRoutesBetweenCities(FlightDAOFactory flightDAL, string start, string end)
        {
            List<Route> lst = flightDAL.getFlightDALInstance().getAllRoutesBetweenCities(start, end);
            if (lst != null)
            {
                Console.WriteLine("------ Listing routes between "+start +" and " +end +" ----- ");
                foreach (Route d in lst)
                {
                    Console.WriteLine(d.RouteID+" - Starts From - " + d.StartCity+ ", Ends At - "+ d.EndCity +", Time - "+ d.FlightTime+", Adult/Child Fare - "+d.AdultFare+"/"+d.ChildFare );
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Routes in the database !!!");
            }
        }

        private bool checkAvailability(FlightDAOFactory flightDAL, int iRouteID, int numSeats, DateTime dtFlight)
        {
            //get the capacity of the flight for the route
            Route r = flightDAL.getFlightDALInstance().getRouteDetails(iRouteID);
            if (r == null)
            {
                Console.WriteLine("Route not available");
                return false;
            }
            int capacity = r.Flight.Capacity;

            //get the list of reservations done for the route on the given date
            List<Reservation> lstReserve = flightDAL.getFlightDALInstance().getAllReservationsForDateOnRoute(iRouteID, dtFlight);
            if (lstReserve == null)
            {
                Console.WriteLine("No tickets booked yet for the flight on route - {0}", iRouteID);
                return true;
            }
            int totalCount = 0;
            foreach(Reservation res in lstReserve){
                totalCount += res.Passengers.Count();
            }
            if ((capacity - totalCount) < numSeats)
            {
                Console.WriteLine("Seats - {0} are not available. Capacity ({1}) No of Reserved seats ({2})", numSeats, capacity, totalCount);
                return false;
            }
            else
            {
                Console.WriteLine("Seats - {0} are available. Capacity ({1}) No of Reserved seats ({2})", numSeats, capacity, totalCount);
            }
            return true;
        }

        private void saveReservation(FlightDAOFactory flightDAL)
        {
            IFlightDAL flightD = flightDAL.getFlightDALInstance();

            string sMainReservationStr = generateReservationID(8);
            List<Passenger> lstPassengers = new List<Passenger>();
            //using (var context = new Context())
            {
                for (int i = 0; i < 6; i++)
                {
                    Passenger p = new Passenger();
                    p.PassengerID = flightD.getNextPassengerID()+i;
                    p.PassengerName = "Temp" + i;
                    p.PassportNo = generateReservationID(6).ToUpper();
                    p.ExpiryDate = DateTime.Now.AddDays(150);
                    p.ReservationID = sMainReservationStr;
                    
                    lstPassengers.Add(p);
                }
                try
                {
                    //Set the date of flight
                    DateTime dtFlight = DateTime.Now.AddDays(2);
                    //check if seats are available
                    if (checkAvailability(flightDAL, 0, lstPassengers.Count, dtFlight))
                    {
                        Reservation r = new Reservation();
                        r.ReservationID = sMainReservationStr;
                        r.RouteID = 0;
                        r.ReservationDate = DateTime.Now;
                        r.FlightDate = dtFlight;
                        Console.WriteLine("Reservation {0} saved", sMainReservationStr);

                        //add the first passenger from the list to the passengerlists
                        foreach (Passenger p in lstPassengers)
                            r.Passengers.Add(p);
                        flightD.saveReservation(r);
                    }
                    else
                    {
                        throw new FlightException("Seats not available on the route selected!");
                    }
                }
                catch (FlightException f)
                {
                    Console.WriteLine(f.Message);
                }
            }
        }

        private void listAllReservations(FlightDAOFactory flightDAL)
        {
            List<Reservation> lst = flightDAL.getFlightDALInstance().getAllReservations();
            if (lst != null)
            {
                Console.WriteLine("------ Listing all the reservations ----- ");
                foreach (Reservation r in lst)
                {
                    Console.WriteLine("Reservation - {0} booked on {1} for {2} people", 
                        r.ReservationID, r.FlightDate.ToString("dd MM yyyy"), r.Passengers.Count);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Reservation in the database !!!");
            }
        }

        private void listReservationsOnRoute(FlightDAOFactory flightDAL, int iRouteID)
        {
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
