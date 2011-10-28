﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Flight.BLL;
using Flight_DAL;

namespace FlightQueryService
{
    [ServiceContract]
    public interface IFlightQueryService
    {
        [OperationContract]
        Destination[] getListOfDestinations();

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