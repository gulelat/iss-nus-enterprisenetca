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
        private string endCityName;

        [DataMember(Name="Destination")]  
        public string EndCityName
        {
            get { return endCityName; }
            set { endCityName = value; }
        }
        private string endCityCode;

        [DataMember(Name="DestinationCode")]  
        public string EndCityCode
        {
            get { return endCityCode; }
            set { endCityCode = value; }
        }

        private string flightDate;

        [DataMember(Name="DepartureDate")]  
        public string FlightDate
        {
            get { return flightDate; }
            set { flightDate = value; }
        }
        private string flightTime;

        [DataMember(Name="Departure Time")]  
        public string FlightTime
        {
            get { return flightTime; }
            set { flightTime = value; }
        }

        private double adultRate;

        [DataMember]  
        public double AdultRate
        {
            get { return adultRate; }
            set { adultRate = value; }
        }
        private double childRate;

        [DataMember]  
        public double ChildRate
        {
            get { return childRate; }
            set { childRate = value; }
        }
    }
}
