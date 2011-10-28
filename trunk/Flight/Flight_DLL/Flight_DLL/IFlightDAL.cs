using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight_DAL;

/*
 *  * Author - Pragati
 */
namespace Flight_DAL
{
    public interface IFlightDAL
    {
        //Obtain the destination city and code configured in the system
        List<Destination> getAllDestinations();

        //save the destinations
        int saveDestination(Destination d);

        //Get Flight routes information for the flights between the two cities
        List<Route> getAllRoutesBetweenCities(string startCity, string destCity);

        //Get Flight routes plying between two cities - for a range of dates
        List<Route> getAllRoutesBetweenCitiesOnDates(string startCityCode, string destinationCode, DateTime start, DateTime end);

        List<Route> getAllRoutes();

        //Get capacity for a given flight
        int getCapacity(string FlightID);

        //Make reservation on a flight
        int saveReservation(Reservation r);

        //Save Passenger details
        int savePassenger(Passenger p);

        //Get route details
        Route getRouteDetails(int iRouteID);
        int saveRoute(Route r);

        //Get Reservation details
        Reservation getReservationDetails(string sReservationID);
        List<Reservation> getAllReservations();

        //get the flight details
        Flight getFlightDetails(string sFlightID);
        List<Flight> getAllFlightDetails();

        //get all the reservations done for a given date for a given route
        List<Reservation> getAllReservationsForDateOnRoute(int iRouteID, DateTime dtFlight);

        //FUNCTIONS - to get the next incremented ID from the database
        int getNextPassengerID();
        int getNextRouteID();
    }
}
