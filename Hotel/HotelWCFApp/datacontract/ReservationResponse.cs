using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net.Security;


namespace DataInfo
{
    [MessageContract]
    public class ReservationResponse
    {
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public String responseCode { set; get; }
    }
}