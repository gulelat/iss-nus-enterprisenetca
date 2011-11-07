using System;
using System.Runtime.Serialization;

namespace WcfFlightService
{
    [DataContract]
    public class PassengerInfo
    {
        [DataMember]
        private string passengerName;

        public string PassengerName
        {
            get { return passengerName; }
            set { passengerName = value; }
        }

        [DataMember]
        private string passportNo;

        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }

        [DataMember]
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

    }
}
