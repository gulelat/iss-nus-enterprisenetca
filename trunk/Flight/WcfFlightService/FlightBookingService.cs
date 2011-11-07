using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Flight.BLL;
using Flight_DAL;

namespace WcfFlightService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public partial class FlightBookingService: IFlightBookingService
    {
        private FlightBLLFacade myFlightBLL = new FlightBLLFacade();
       
        [OperationBehavior(TransactionScopeRequired = true)]
        public bool makeReservation(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, PassengerInfo[] passengers, PaymentInfo pInfo)
        {
            Console.WriteLine("Making reservation for {0} to {1} on {2} for {3} Passengers", sStartCityCode, sEndCityCode, dtFlightDate.ToString(), passengers.Count());
            List<Flight_DAL.Route> lstRoutes;
            bool bStatus = false;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes != null)
            {
                Console.WriteLine("Obtained the list of routes. Count - " + lstRoutes.Count);
                Route r = (from ro in lstRoutes
                           where ro.FlightTime.Equals(dtFlightDate.ToString("HH:mm"))
                           select ro).FirstOrDefault();
                if (r != null)
                {
                    Console.WriteLine("Obtained the route information");
                    List<Passenger> lstPassengers = getPassengerList(passengers);
                    string sReservationID;
                    lock (this)
                    {
                        sReservationID = myFlightBLL.getFlightBLLInstance().reserveFlight(r.RouteID, dtFlightDate, lstPassengers);
                        bStatus = myFlightBLL.getFlightBLLInstance().makePayment(sReservationID, getPaymentDetails(pInfo));
                    }
                }
            }
            
            return bStatus;   //default value
        }

        private Flight.BLL.Entity.PaymentDetails getPaymentDetails(PaymentInfo pInfo)
        {
            Flight.BLL.Entity.PaymentDetails pDets = new Flight.BLL.Entity.PaymentDetails();
            pDets.CardHolderName = pInfo.Cardholdername;
            pDets.CardName = pInfo.Cardname;
            pDets.CardExpiryDate = pInfo.ExpiryDate;
            pDets.Cv2 = pInfo.Cv2;
            return pDets;
        }

        private List<Passenger> getPassengerList(PassengerInfo[] passengers)
        {
            List<Passenger> lstPassenger = new List<Passenger>();
            Passenger p;
            foreach (PassengerInfo pInfo in passengers)
            {
                p = new Passenger();
                p.PassengerName = pInfo.PassengerName;
                p.PassportNo = pInfo.PassportNo;
                p.ExpiryDate = pInfo.ExpiryDate;
                lstPassenger.Add(p);
            }
            return lstPassenger;
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public bool checkAvailability(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats)
        {
            Console.WriteLine("In checkIfAvailable({0}, {1}, {2}, {3}) .... ", sStartCityCode, sEndCityCode, dtFlightDate.ToString(), iNumSeats);
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes != null)
            {
                int iAvailable;
                Route r = (from ro in lstRoutes
                           where ro.FlightTime.Equals(dtFlightDate.ToString("HH:mm"))
                           select ro).FirstOrDefault();
                if (r != null)
                {
                    iAvailable = getNumSeatsAvailable(r, dtFlightDate);
                    if (iAvailable >= iNumSeats) return true;
                }
                else
                    return false;
            }
            return false;  //seats are available.
        }

        private int getNumSeatsAvailable(Route r, DateTime dtFlight)
        {
            int capacity = r.Flight.Capacity;
            //            Console.WriteLine("Flight capacity - {0}", capacity);

            //get the list of reservations done for the route - includes all the dates
            List<Reservation> lstReserve = r.Reservations.ToList();
            if (lstReserve == null)
                return capacity;

            int totalCount = 0;
            //get the reservations done for the date of flight
            foreach (Reservation rsv in lstReserve)
            {
                if (DateTime.Compare(rsv.FlightDate, dtFlight) == 0)
                    totalCount += rsv.Passengers.Count();
            }
            //            Console.WriteLine("Total reservations found - {0}", totalCount);

            return (capacity - totalCount);
        }
    }
}
