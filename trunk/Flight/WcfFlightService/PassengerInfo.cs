using System;
using System.Runtime.Serialization;

namespace WcfFlightService
{
    [DataContract]
    public class PassengerInfo
    {
        [DataMember(IsRequired=true)]
        private string passengerName;

        public string PassengerName
        {
            get { return passengerName; }
            set { passengerName = value; }
        }

        [DataMember(IsRequired = true)]
        private string passportNo;

        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }

        [DataMember(IsRequired = true)]
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

    }
}
