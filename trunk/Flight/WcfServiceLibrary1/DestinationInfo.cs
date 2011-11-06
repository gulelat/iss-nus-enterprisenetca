using System.Runtime.Serialization;

namespace WcfServiceLibrary1
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
