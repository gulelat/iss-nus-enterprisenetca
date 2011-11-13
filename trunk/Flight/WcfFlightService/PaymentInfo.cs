using System;
using System.Runtime.Serialization;

namespace WcfFlightService
{
    [DataContract]
    public class PaymentInfo
    {
        [DataMember(IsRequired = true)]
        private string cardholdername;

        public string Cardholdername
        {
            get { return cardholdername; }
            set { cardholdername = value; }
        }

        [DataMember]
        private string cardname;

        public string Cardname
        {
            get { return cardname; }
            set { cardname = value; }
        }

        [DataMember(IsRequired = true)]
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        [DataMember(IsRequired = true)]
        private string cv2;

        public string Cv2
        {
            get { return cv2; }
            set { cv2 = value; }
        }
    }
}
