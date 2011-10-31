using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net.Security;

namespace DataInfo
{
    [MessageContract]
    public class ReservationRequest
    {
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public String RoomNo { get; set; }
        [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public String GuestName { get; set; }
        [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public String GuestPassport { get; set; }
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public String StartDate { get; set; }
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public int Duration { get; set; }
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public int NumOfGuest { get; set; }
        [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public String GuestAccount { get; set; }
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public String TotalCharge { get; set; }
        [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public String CardType { get; set; }

    }
}
