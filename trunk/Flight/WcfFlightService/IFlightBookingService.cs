using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfFlightService
{
   [ServiceContract(Namespace = "WcfFlightService", SessionMode = SessionMode.Required)]
    public interface IFlightBookingService
    {
       [OperationContract]
       bool makeReservation(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, PassengerInfo[] passengers, PaymentInfo pInfo);

       [OperationContract]
       bool checkAvailability(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats);

    }
}
