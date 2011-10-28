using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight.BLL;
using System.ServiceModel;

namespace FlightQueryService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single,
                        ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class FlightQueryService :IFlightQueryService
    {
        private FlightBLLFacade myFlightBLL;

        public Flight_DAL.Destination[] getListOfDestinations()
        {
            throw new NotImplementedException();
        }

        public FlightInfo[] getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode)
        {
            throw new NotImplementedException();
        }

        public FlightInfo[] getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode, string sEndCityCode, DateTime dtStartDate, DateTime dtEndDate, int numSeats)
        {
            throw new NotImplementedException();
        }

        public bool checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats)
        {
            throw new NotImplementedException();
        }
    }
}
