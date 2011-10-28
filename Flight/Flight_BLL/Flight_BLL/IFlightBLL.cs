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
       
        //get all the flight routes plying between the two cities within a range of dates
        List<Route> getAvailableFlightBetweenCitiesOnDates(string startCity, string destCity, DateTime startDt, DateTime endDt, int numSeats);

        //check if the flight selected is available
        bool checkIfAvailable(int iRouteID, DateTime dtFlight, int numSeats);

        //Book the flight - returns the ticketing reference
        string reserveFlight(int iRouteID, DateTime dtFlight, List<Passenger> lstPassengers);

        //make the payment - against the ticketing reference
        bool makePayment(string sReservations, PaymentDetails pDetails);
    }
}
