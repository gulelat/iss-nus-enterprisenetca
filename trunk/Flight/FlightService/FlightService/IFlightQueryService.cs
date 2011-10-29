using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Flight.BLL;
using Flight_DAL;

namespace FlightService
{
    [ServiceContract]
    public interface IFlightQueryService
    {
        [OperationContract]
        DestinationInfo[] getListOfDestinations();

        [OperationContract]
        FlightInfo[] getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode);

        [OperationContract]
        FlightInfo[] getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode,
                                                                    string sEndCityCode,
                                                                    DateTime dtStartDate,
                                                                    DateTime dtEndDate, 
                                                                    int numSeats);
        [OperationContract]
        bool checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats);
    }
}
