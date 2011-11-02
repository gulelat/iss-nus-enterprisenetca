using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FlightService
{
   [ServiceContract(Namespace = "FlightService")]
    public interface IFlightBookingService
    {
       [OperationContract]
       bool makeReservation(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, PassengerInfo[] passengers, PaymentInfo pInfo);

       [OperationContract]
       bool checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats);

    }
}
