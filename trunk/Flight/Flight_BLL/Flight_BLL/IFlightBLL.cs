using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight_DAL;
using Flight.BLL.Entity;

/*
 * Author - Pragati
 */
namespace Flight.BLL
{
    public interface IFlightBLL
    {
        //get all the destinations to which the flight operates
        List<Destination> getAllDestinations();

        //get all the flight routes plying between two cities
        List<Route> getFlightsBetweenCities(string startCityCode, string destCityCode);

        //check if the flight selected is available
        bool checkIfAvailable(int iRouteID, DateTime dtFlight, int numSeats);

        //Book the flight - returns the ticketing reference
        string reserveFlight(int iRouteID, DateTime dtFlight, List<Passenger> lstPassengers);

        //make the payment - against the ticketing reference
        bool makePayment(string sReservations, PaymentDetails pDetails);

        //get the reservations for a given route for the given ID and date
        List<Reservation> getAllReservationsForDateOnRoute(int iRouteID, DateTime dtFlight);


    }
}
