using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfFlightService
{
    public interface IFlightQueryCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnFlightIDQueryCallback(String[] flights);

        [OperationContract(IsOneWay = true)]
        void onDestinationQueryCallback(DestinationInfo[] destinations);

        [OperationContract(IsOneWay = true)]
        void onAvailabilityQueryCallback(bool status);

        [OperationContract(IsOneWay = true)]
        void onFlightInfoQueryCallback(FlightInfo[] flights);
    }
}
