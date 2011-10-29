using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace FlightService
{
    [DataContract]
    public class DestinationInfo
    {
        private string cityName;

        [DataMember]
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        private string cityCode;

        [DataMember]
        public string CityCode
        {
            get { return cityCode; }
            set { cityCode = value; }
        }

    }
}
