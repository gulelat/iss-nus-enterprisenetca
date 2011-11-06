using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
   [ServiceContract(Namespace = "WcfServiceLibrary1", SessionMode=SessionMode.NotAllowed)]
    public interface IFlightBookingService
    {
       [OperationContract]
       bool makeReservation(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, PassengerInfo[] passengers, PaymentInfo pInfo);

       [OperationContract]
       bool checkAvailability(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats);

    }
}
