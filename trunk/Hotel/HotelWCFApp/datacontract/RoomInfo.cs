using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace DataInfo
{
    [DataContract]
   public class RoomInfo
    {
         [DataMember]
        public String roomNo{set;get;}
         [DataMember]
        public String roomType{set;get;}
         [DataMember]
        public String capacity{set;get;}
         [DataMember]
        public String dailyCharge{set;get;}
   


    }
}
