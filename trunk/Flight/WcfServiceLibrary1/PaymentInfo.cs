using System;
using System.Runtime.Serialization;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class PaymentInfo
    {
        [DataMember]
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

        [DataMember]
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        [DataMember]
        private string cv2;

        public string Cv2
        {
            get { return cv2; }
            set { cv2 = value; }
        }
    }
}
