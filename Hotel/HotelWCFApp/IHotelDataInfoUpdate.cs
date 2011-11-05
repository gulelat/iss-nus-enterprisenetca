using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataInfo;

namespace HotelWCFApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelDataInfoUpdate" in both code and config file together.
    [ServiceContract]
    public interface IHotelDataInfoUpdate
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
         Boolean checkRoomAvailability(string roomNo, string startDateStr, int duration);
        [OperationContract]
        [FaultContract(typeof(Exception))]
        ReservationResponse makeRoomReservation(ReservationRequest request);

    }
}
