using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight_DAL;

/*
 DAL Implementation class. 
 * Author - Pragati
 */
namespace Flight_DAL
{
    public class FlightDAL: IFlightDAL
    {
        private FlightDBEntities1 flightContext;

        public FlightDAL()
        {
            flightContext = new FlightDBEntities1();
        }

        //Obtain the destination city and code configured in the system
        public List<Destination> getAllDestinations()
        {
            List<Destination> lstDestination=null;
            var destinationQuery = from f in flightContext.Destinations select f;
            if(destinationQuery == null) return null;
            if (destinationQuery.Count() == 0) return null;

            //update the list with the destinations 
            Destination dest;
            lstDestination = new List<Destination>();
            foreach (var destination in destinationQuery)
            {
                dest = new Destination();
                dest.CityCode = destination.CityCode;
                dest.City = destination.City;
                lstDestination.Add(dest);
            }
            return lstDestination;

        }

        public List<Route> getAllRoutesBetweenCities(string startCity, string destCity)
        {
            var rQuery = from r in flightContext.Routes
                         where r.StartCity.Equals(startCity) && (r.EndCity.Equals(destCity))
                         select r;
            if (rQuery == null) return null;
            if (rQuery.Count() == 0) return null;
            Route route;
            List<Route> lstRoute = new List<Route>();
            foreach (var ro in rQuery)
            {
                route = new Route();
                route.RouteID = ro.RouteID;
                route.FlightID = ro.FlightID;
                route.FlightTime = ro.FlightTime;
                route.StartCity = ro.StartCity;
                route.EndCity = ro.EndCity;
                route.AdultFare = ro.AdultFare;
                route.ChildFare = ro.ChildFare;
                //add the flight details
                route.Flight = ro.Flight;
                lstRoute.Add(route);
            }
            return lstRoute;
        }

        //Get Flight routes going to a given destination - for a range of dates
        //same as above, as we assume that the flights operate 7 days a week. 
        public  List<Route> getAllRoutesBetweenCitiesOnDates(string startCityCode, string destinationCode, DateTime start, DateTime end)
        {
            var rQuery = from r in flightContext.Routes
                         where r.StartCity.Equals(startCityCode) && (r.EndCity.Equals(destinationCode))
                         select r;
            if(rQuery == null) return null;
            if(rQuery.Count() == 0) return null;
            Route route;
            List<Route> lstRoute = new List<Route>();
            foreach(var ro in rQuery)
            {
                route = new Route();
                route.RouteID = ro.RouteID;
                route.FlightID = ro.FlightID;
                route.FlightTime = ro.FlightTime;
                route.StartCity = ro.StartCity;
                route.EndCity = ro.EndCity;
                route.AdultFare = ro.AdultFare;
                route.ChildFare = ro.ChildFare;
                route.Flight = ro.Flight;
                lstRoute.Add(route);
            }
            return lstRoute;
        }

        //Get capacity for a given flight
        public int getCapacity(string FlightID)
        {
            Flight flight = (from f in flightContext.Flights 
                          where f.FlightID.Equals(FlightID )
                          select f).FirstOrDefault();
            if (flight == null) return 0;
            return flight.Capacity;
        }

        //Make reservation on a flight
        public int saveReservation(Reservation r)
        {
            try
            {
                flightContext.AddToReservations(r);
                foreach (Passenger p in r.Passengers)
                {
                    flightContext.AddToPassengers(p);
                }
                return flightContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new FlightException("Error thrown while saving the Reservations- "+e.Message);
            }
        }

        public int savePassenger(Passenger p)
        {
            try
            {
                flightContext.AddToPassengers(p);
                return flightContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new FlightException("Error saving the Passenger details- "+e.Message);
            }
        }
        
        //Get route details
        public Route getRouteDetails(int iRouteID)
        {
            Route r = (from route in flightContext.Routes
                       where route.RouteID == iRouteID
                       select route).FirstOrDefault();
            if (r == null) return null;
            return r;
        }

        //Get Reservation details
        public Reservation getReservationDetails(string sReservationID)
        {
            Reservation r = (from reservation in flightContext.Reservations
                             where reservation.ReservationID.Equals(sReservationID)
                             select reservation).FirstOrDefault();
            if (r == null) return null;
            return r;
        }

        public List<Reservation> getAllReservations()
        {
            flightContext.ContextOptions.LazyLoadingEnabled = false;
            var rQuery = from r in flightContext.Reservations
                          select r;
            if (rQuery == null) return null;
            if (rQuery.Count() == 0) return null;
            Reservation res = null;
            List<Reservation> lstReservation = new List<Reservation>();
            foreach (var reserve in rQuery)
            {
                if (!reserve.Passengers.IsLoaded)
                    reserve.Passengers.Load();
                res = new Reservation();
                res.ReservationID = reserve.ReservationID;    //set reservationid
                res.ReservationDate = reserve.ReservationDate; //set reservation date
                res.RouteID = reserve.RouteID;                //set route id
                res.FlightDate = reserve.FlightDate;            //set the flight date
                //todo - add the passenger list to the reservation. 
                //res.Passengers = reserve.Passengers;
                reserve.Passengers.ToList().ForEach(p => res.Passengers.Add(p));
                lstReservation.Add(res);
            }
            return lstReservation;

        }

        public Flight getFlightDetails(string sFlightID)
        {
            Flight f = (from flight in flightContext.Flights
                        where flight.FlightID.Equals(sFlightID)
                        select flight).FirstOrDefault();
            if (f == null) return null;
            return f;
        }

        public List<Flight> getAllFlightDetails()
        {
            var f = from flight in flightContext.Flights
                        select flight;
            if (f == null) return null;
            if (f.Count() == 0) return null;
            List<Flight> lstFlight = new List<Flight>();
            foreach (Flight fD in f)
            {
                lstFlight.Add(fD);
            }
            return lstFlight;
        }

        //get all the reservations done for a given date for a given route
        public List<Reservation> getAllReservationsForDateOnRoute(int iRouteID, DateTime dtFlight)
        {
            var rQuery = (from r in flightContext.Reservations
                          where r.RouteID == iRouteID && r.FlightDate.Equals(dtFlight)
                          select r);
            if (rQuery == null) return null;
            if (rQuery.Count() == 0) return null;
            Reservation res = null;
            List<Reservation> lstReservation = new List<Reservation>();
            foreach (var reserve in rQuery)
            {
                res = new Reservation();
                res.ReservationID = reserve.ReservationID;    //set reservationid
                res.ReservationDate = reserve.ReservationDate; //set reservation date
                res.RouteID = reserve.RouteID;                //set route id
                res.FlightDate = reserve.FlightDate;           // set the flight date
                reserve.Passengers.ToList().ForEach(p => res.Passengers.Add(p));
                lstReservation.Add(res);
            }
            return lstReservation;
        }

        public int getNextPassengerID()
        {
            var queryStr = from idQuery in flightContext.Passengers
                           select idQuery.PassengerID;
            if (queryStr == null) return 0;
            if (queryStr.Count() == 0) return 0;
            //else get the next no. 
            int iID = (queryStr).Max() + 1;
            return iID;
        }

        public int getNextRouteID()
        {
            var queryStr = from idQuery in flightContext.Routes
                       select idQuery.RouteID;
            if(queryStr == null) return 0;
            if(queryStr.Count() == 0) return 0;
            //else get the next no. 
            int iID = (queryStr).Max() + 1;
            return iID;
        }

        public int saveDestination(Destination d)
        {
            try
            {
                flightContext.AddToDestinations(d);
                return flightContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new FlightException("Error saving the Destination record... make sure the CityCode is unique");
            }
        }

        public int saveRoute(Route r)
        {
            try
            {
                flightContext.AddToRoutes(r);
                return flightContext.SaveChanges();
            }
            catch (Exception )
            {
                throw new FlightException("Error saving the route record.... ");
            }
        }

        public List<Route> getAllRoutes()
        {
            var rQuery = from r in flightContext.Routes
                         select r;
            if (rQuery == null) return null;
            if (rQuery.Count() == 0) return null;
            Route route;
            List<Route> lstRoute = new List<Route>();
            foreach (var ro in rQuery)
            {
                route = new Route();
                route.RouteID = ro.RouteID;
                route.FlightID = ro.FlightID;
                route.FlightTime = ro.FlightTime;
                route.StartCity = ro.StartCity;
                route.EndCity = ro.EndCity;
                route.AdultFare = ro.AdultFare;
                route.ChildFare = ro.ChildFare;
                lstRoute.Add(route);
            }
            return lstRoute;
        }
    }
}
