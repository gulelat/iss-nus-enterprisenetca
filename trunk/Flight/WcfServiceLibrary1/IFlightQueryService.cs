using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Flight.BLL;
using Flight_DAL;

namespace WcfServiceLibrary1
{
    [ServiceContract(Namespace = "WcfServiceLibrary1", SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IFlightQueryCallback))]
    public interface IFlightQueryService
    {
        [OperationContract(IsOneWay = true)]
        void getAllFlightIDs(string sStartCityCode, string sEndCityCode);

        [OperationContract(IsOneWay = true)]
        void getListOfDestinations();

        [OperationContract(IsOneWay = true)]
        void getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode);

        [OperationContract(IsOneWay = true)]
        void getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode,
                                                                    string sEndCityCode,
                                                                    DateTime dtStartDate,
                                                                    DateTime dtEndDate);
        [OperationContract(IsOneWay = true)]
        void checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats);
    }
}
