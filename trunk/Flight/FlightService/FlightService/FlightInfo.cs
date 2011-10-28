using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace FlightQueryService
{
    [DataContract]
    public class FlightInfo
    {
        private int iRouteID;
        private string flightName;
        private string startCityName;
        private string startCityCode;
        private string endCityName;
        private string endCityCode;
        private string flightTime;
        private double adultRate;
        private double childRate;

        [DataMember(Name="ID")]
        public int RouteID
        {
            get { return iRouteID; }
            set { iRouteID = value; }
        }

        [DataMember]        
        public string FlightName
        {
            get { return flightName; }
            set { flightName = value; }
        }

        [DataMember(Name="StartCity")]
        public string StartCityName
        {
            get { return startCityName; }
            set { startCityName = value; }
        }

        [DataMember(Name="StartCode")]
        public string StartCityCode
        {
            get { return startCityCode; }
            set { startCityCode = value; }
        }
        
        [DataMember(Name="Destination")]  
        public string EndCityName
        {
            get { return endCityName; }
            set { endCityName = value; }
        }
        
        [DataMember(Name="DestinationCode")]  
        public string EndCityCode
        {
            get { return endCityCode; }
            set { endCityCode = value; }
        }
               
        [DataMember(Name="Departure Time")]  
        public string FlightTime
        {
            get { return flightTime; }
            set { flightTime = value; }
        }

        
        [DataMember]  
        public double AdultRate
        {
            get { return adultRate; }
            set { adultRate = value; }
        }
        
        [DataMember]  
        public double ChildRate
        {
            get { return childRate; }
            set { childRate = value; }
        }
    }
}
