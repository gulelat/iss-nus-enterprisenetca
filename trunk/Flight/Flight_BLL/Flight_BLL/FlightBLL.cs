﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight_DAL;
using Flight.BLL.Entity;

namespace Flight.BLL
{
    public class FlightBLL : IFlightBLL
    {
        public List<Destination> getAllDestinations()
        {
            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();
            try
            {
                return flightDAL.getFlightDALInstance().getAllDestinations();
            }
            catch (FlightException f)
            {
                Console.WriteLine(f.Message);
                throw f;
            }
        }

        public List<Flight_DAL.Route> getFlightsBetweenCities(string startCityCode, string destCityCode)
        {
            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();
            return flightDAL.getFlightDALInstance().getAllRoutesBetweenCities(startCityCode, destCityCode);
        }

        //todo - remove the constraint on the number of seats. Send the number of seats available to the client
        public List<Route> getAvailableFlightBetweenCitiesOnDates(string startCity, string destCity, DateTime startDt, DateTime endDt, int numSeats)
        {
            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();
            List<Route> lstRoute = flightDAL.getFlightDALInstance().getAllRoutesBetweenCities(startCity, destCity);

            List<Route> lstAvailableRoutes = new List<Route>();
            DateTime dtFlight = DateTime.Now;

            Route aR;
            foreach (Route r in lstRoute)
            {
                dtFlight = startDt;
                while (dtFlight < endDt)
                {
                    if (getNumSeatsAvailable(r, dtFlight) >= numSeats)
                    {
                        aR = new Route();
                        aR.RouteID = r.RouteID;
                        aR.AdultFare = r.AdultFare;
                        aR.ChildFare = r.ChildFare;
                        aR.Destination = r.Destination;
                        aR.StartCity = r.StartCity;
                        aR.EndCity = r.EndCity;
                        aR.Flight = r.Flight;
                        aR.FlightTime = dtFlight.ToString("dd MMM yyy ") + r.FlightTime;
                        lstAvailableRoutes.Add(aR);
                    }
                    dtFlight = dtFlight.AddDays(1);
                }
            }

            return lstAvailableRoutes;
        }

        private int getNumSeatsAvailable(Route r, DateTime dtFlight)
        {
            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();
            int capacity = r.Flight.Capacity;

            //get the list of reservations done for the route on the given date
            List<Reservation> lstReserve = flightDAL.getFlightDALInstance().getAllReservationsForDateOnRoute(r.RouteID, dtFlight);
            if (lstReserve == null)
                return r.Flight.Capacity;
            
            int totalCount = 0;
            foreach (Reservation res in lstReserve)
                totalCount += res.Passengers.Count();
            return (capacity - totalCount);
        }

        public bool checkIfAvailable(int iRouteID, DateTime dtFlight, int numSeats)
        {
            FlightDAOFactory flightDAL = FlightDAOFactory.getInstance();
            //get the capacity of the flight for the route
            Route r = flightDAL.getFlightDALInstance().getRouteDetails(iRouteID);
            if (r == null) return false;
            int capacity = r.Flight.Capacity;

            //get the list of reservations done for the route on the given date
            List<Reservation> lstReserve = flightDAL.getFlightDALInstance().getAllReservationsForDateOnRoute(iRouteID, dtFlight);
            if (lstReserve == null)
            {
                Console.WriteLine("No tickets booked yet for the flight on route - {0}", iRouteID);
                return true;
            }
            int totalCount = 0;
            foreach (Reservation res in lstReserve)
                totalCount += res.Passengers.Count();
            if ((capacity - totalCount) < numSeats) return false;
            return true;            
        }

        public string reserveFlight(int iRouteID, DateTime dtFlight, List<Flight_DAL.Passenger> lstPassengers)
        {
            IFlightDAL flightDAL = FlightDAOFactory.getInstance().getFlightDALInstance();
            //Generate a ReservationID of length 8
            string sMainReservationStr= generateReservationID(8);
            int iPassengerID = flightDAL.getNextPassengerID();  //get the last id of the passenger stored in database
            try
            {
                //check if seats are available
                if (checkIfAvailable(iRouteID, dtFlight, lstPassengers.Count))
                {
                    Reservation r = new Reservation();
                    r.ReservationID = sMainReservationStr;
                    r.RouteID = iRouteID;
                    r.ReservationDate = DateTime.Now;
                    r.FlightDate = dtFlight;
                    //add the first passenger from the list to the passengerlists
                    foreach (Passenger p in lstPassengers)
                    {
                        p.PassengerID = iPassengerID++;
                        p.ReservationID = sMainReservationStr;
                        r.Passengers.Add(p);
                    }
                    flightDAL.saveReservation(r);
                    return sMainReservationStr;
                }
                else
                {
                    throw new FlightException("Seats not available on the route selected!");
                }
            }
            catch (FlightException f)
            {
                Console.WriteLine(f.Message);
                throw f;
            }
        }


        public bool makePayment(string sReservations, PaymentDetails pDetails)
        {
            //dummy method assumes that the payment is paid successfully via a payment gateway.
            return true;
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
