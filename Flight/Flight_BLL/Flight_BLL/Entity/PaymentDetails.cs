using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight.BLL.Entity
{
    public class PaymentDetails
    {
        private string cardName;

        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }

        private string cardHolderName;

        public string CardHolderName
        {
            get { return cardHolderName; }
            set { cardHolderName = value; }
        }
        private DateTime cardExpiryDate;

        public DateTime CardExpiryDate
        {
            get { return cardExpiryDate; }
            set { cardExpiryDate = value; }
        }
        private string cv2;

        public string Cv2
        {
            get { return cv2; }
            set { cv2 = value; }
        }


    }
}
