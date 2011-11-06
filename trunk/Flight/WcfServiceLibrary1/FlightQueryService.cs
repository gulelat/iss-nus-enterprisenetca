using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight.BLL;
using Flight_DAL;
using System.ServiceModel;
using System.Globalization;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession,
                        ConcurrencyMode=ConcurrencyMode.Single)]
    public partial class FlightQueryService :IFlightQueryService
    {
        private FlightBLLFacade myFlightBLL=new FlightBLLFacade();

        [OperationBehavior (TransactionScopeRequired=false)]
        public void getListOfDestinations()
        {
            Console.WriteLine("In getListOfDestinations() function .... ");
            IFlightQueryCallback callerProxy = OperationContext.Current.GetCallbackChannel<IFlightQueryCallback>();
            List<DestinationInfo> lstReturn = new List<DestinationInfo>();
            List<Destination> lstDestination;
            lock (this)
            {
                lstDestination = myFlightBLL.getFlightBLLInstance().getAllDestinations();
            }
            if (lstDestination == null)
            {
                callerProxy.onDestinationQueryCallback(null);
            }
            else
            {
                DestinationInfo dInfo;
                foreach (Destination d in lstDestination)
                {
                    dInfo = new DestinationInfo();
                    dInfo.CityName = d.City;
                    dInfo.CityCode = d.CityCode;
                    lstReturn.Add(dInfo);
                }
                callerProxy.onDestinationQueryCallback(lstReturn.ToArray());
            }
        }

        /**
         * Get the list of flight details operating between two cities. Note that we assume that all the flights operate
         * everyday, and thus the date part of the FlightTime needs to be ignored. 
         **/
        [OperationBehavior(TransactionScopeRequired = false)]
        public void getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode)
        {
            Console.WriteLine("In getListOfAllFlightsBetweenCities({0}, {1}) function... ", sStartCityCode, sEndCityCode);
            IFlightQueryCallback callerProxy = OperationContext.Current.GetCallbackChannel<IFlightQueryCallback>();
            CultureInfo provider = CultureInfo.InvariantCulture;

            List<FlightInfo> lstReturn = new List<FlightInfo>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes == null)
            {

                callerProxy.onFlightInfoQueryCallback(null);
            }
            else
            {
                Console.WriteLine("Found - {0} routes", lstRoutes.Count);
                FlightInfo fInfo;
                foreach (Route r in lstRoutes)
                {
                    fInfo = new FlightInfo();
                    fInfo.RouteID = r.RouteID;
                    fInfo.AdultRate = r.AdultFare;
                    fInfo.ChildRate = r.ChildFare;
                    fInfo.EndCityCode = r.Destination1.CityCode;
                    fInfo.EndCityName = r.Destination1.City;
                    fInfo.StartCityCode = r.Destination.CityCode;
                    fInfo.StartCityName = r.Destination.City;
                    fInfo.FlightName = r.Flight.FlightID;
                    fInfo.FlightTime = DateTime.ParseExact(r.FlightTime, "HH:mm", null);    //only time component
                    Console.WriteLine(fInfo.ToString());
                    lstReturn.Add(fInfo);
                }
                callerProxy.onFlightInfoQueryCallback(lstReturn.ToArray());
            }
        }

        /*
         * Obtains a list of all the flights flying between the two given cities. In the FlightInfo objects returned, the date
         * component is valid. 
         */
        [OperationBehavior(TransactionScopeRequired = false)]
        public void getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode, string sEndCityCode, 
            DateTime dtStartDate, DateTime dtEndDate)
        {
            Console.WriteLine("In getListOfAllAvailableFlightsBetweenCitiesOnDates({0}, {1}, {2}, {3})", 
                sStartCityCode, sEndCityCode, dtStartDate.ToString(), dtEndDate.ToString());

            IFlightQueryCallback callerProxy = OperationContext.Current.GetCallbackChannel<IFlightQueryCallback>();
            CultureInfo provider = CultureInfo.InvariantCulture;

            List<FlightInfo> lstReturn = new List<FlightInfo>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes == null)
            {
                Console.WriteLine("No routes found");
                callerProxy.onFlightInfoQueryCallback(null);
            }
            else
            {
//                Console.WriteLine("Found - {0} routes", lstRoutes.Count);
                DateTime dtFlight = DateTime.Now;
                FlightInfo fInfo;
                string sDate;
                foreach (Route r in lstRoutes)
                {
                    dtFlight = dtStartDate;
                    while (dtFlight < dtEndDate)
                    {
//                        Console.WriteLine("Checking route {1} for date - {0}", dtFlight.ToString(), r.RouteID);
                        fInfo = new FlightInfo();
                        fInfo.RouteID = r.RouteID;
                        fInfo.AdultRate = r.AdultFare;
                        fInfo.ChildRate = r.ChildFare;
                        fInfo.EndCityCode = r.Destination1.CityCode;
                        fInfo.EndCityName = r.Destination1.City;
                        fInfo.StartCityCode = r.Destination.CityCode;
                        fInfo.StartCityName = r.Destination.City;
                        fInfo.FlightName = r.Flight.FlightID;
                        sDate = dtFlight.ToString("dd MMM yyyy ") + r.FlightTime;
                        fInfo.FlightTime = DateTime.ParseExact(sDate, "dd MMM yyyy HH:mm", null);    //date+time component
                        fInfo.NumSeatsAvailable = getNumSeatsAvailable(r, fInfo.FlightTime);
//                        Console.WriteLine(fInfo.ToString());
                        lstReturn.Add(fInfo);
                        dtFlight = dtFlight.AddDays(1);
                    }
                }

                callerProxy.onFlightInfoQueryCallback(lstReturn.ToArray());
            }
        }

        /*
         * Checks the reservations done on the given route for the date of flight (includes both 
         * date and time) to find the number of seats reserved on the date of flight. 
         */
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
                if(DateTime.Compare(rsv.FlightDate, dtFlight) ==0)
                    totalCount += rsv.Passengers.Count();
            }
//            Console.WriteLine("Total reservations found - {0}", totalCount);

            return (capacity - totalCount);
        }

        //obtains the route details for the given start to end on the date of flight
        private Route getRoute(string start, string end, DateTime dtFlight)
        {
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(start, end);
            }
            if (lstRoutes != null)
            {
                 //check the time of flight
                Route r = (from ro in lstRoutes
                           where ro.FlightTime.Equals(dtFlight.ToString("HH:mm"))
                           select ro).FirstOrDefault();
                return r;
            }
            return null;
        }

        /*
         * Assumes that the dtFlightDate includes both date and time of flight
         */
        [OperationBehavior(TransactionScopeRequired = false)]
        public void checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats)
        {
            Console.WriteLine("In checkIfAvailable({0}, {1}, {2}, {3}) .... ", sStartCityCode, sEndCityCode, dtFlightDate.ToString(), iNumSeats);
            IFlightQueryCallback callerProxy = OperationContext.Current.GetCallbackChannel<IFlightQueryCallback>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes == null)
            {
                callerProxy.onAvailabilityQueryCallback(false); // no seats available, as no route found
            }
            else
            {
                int iReserved;
                Route r = getRoute(sStartCityCode, sEndCityCode, dtFlightDate);
                if (r == null)
                {
                    callerProxy.onAvailabilityQueryCallback(false); // no seats available, as no route found
                }
                else
                {
                    iReserved = getNumSeatsAvailable(r, dtFlightDate);
                    if (iReserved < iNumSeats)
                    {
                        callerProxy.onAvailabilityQueryCallback(false); //no seats available for the number requested
                        return;
                    }
                }
            }
            callerProxy.onAvailabilityQueryCallback(true);  //seats are available. 
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public void getAllFlightIDs(string sStartCityCode, string sEndCityCode)
        {
            Console.WriteLine("In getAllFlightIDs({0}, {1})", sStartCityCode, sEndCityCode);
            IFlightQueryCallback callerProxy = OperationContext.Current.GetCallbackChannel<IFlightQueryCallback>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes == null)
            {
                callerProxy.OnFlightIDQueryCallback(null);  
            }
            else
            {
                var fl = (from r in lstRoutes
                          select r.Flight.FlightID).Distinct();
                if (fl == null)
                    callerProxy.OnFlightIDQueryCallback(null);  //todo - throw SOAPFault
                else
                    callerProxy.OnFlightIDQueryCallback(fl.ToArray());
            }
        }

        void IFlightQueryService.getAllFlightIDs(string sStartCityCode, string sEndCityCode)
        {
            throw new NotImplementedException();
        }

        void IFlightQueryService.getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode)
        {
            throw new NotImplementedException();
        }

        void IFlightQueryService.getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode, string sEndCityCode, DateTime dtStartDate, DateTime dtEndDate)
        {
            throw new NotImplementedException();
        }

        void IFlightQueryService.checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats)
        {
            throw new NotImplementedException();
        }
    }
}
