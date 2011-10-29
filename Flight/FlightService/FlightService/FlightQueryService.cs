using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight.BLL;
using Flight_DAL;
using System.ServiceModel;

namespace FlightService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single,
                        ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class FlightQueryService :IFlightQueryService
    {
        private FlightBLLFacade myFlightBLL=new FlightBLLFacade();

/*        public FlightQueryService()
        {
            myFlightBLL = new FlightBLLFacade();
        }*/

        [OperationBehavior (TransactionScopeRequired=false)]
        public DestinationInfo[] getListOfDestinations()
        {
            List<DestinationInfo> lstReturn = new List<DestinationInfo>();
            List<Destination> lstDestination;
            lock (this)
            {
                lstDestination = myFlightBLL.getFlightBLLInstance().getAllDestinations();
            }
            if (lstDestination == null) return null;
            DestinationInfo dInfo;
            foreach (Destination d in lstDestination)
            {
                dInfo = new DestinationInfo();
                dInfo.CityName = d.City;
                dInfo.CityCode = d.CityCode;
                lstReturn.Add(dInfo);
            }
            return lstReturn.ToArray();
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public FlightInfo[] getListOfAllFlightsBetweenCities(string sStartCityCode, string sEndCityCode)
        {
            List<FlightInfo> lstReturn = new List<FlightInfo>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getFlightsBetweenCities(sStartCityCode, sEndCityCode);
            }
            if (lstRoutes == null) return null;
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
                fInfo.FlightTime = r.FlightTime;
                lstReturn.Add(fInfo);
            }

            return lstReturn.ToArray();
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public FlightInfo[] getListOfAllAvailableFlightsBetweenCitiesOnDates(string sStartCityCode, string sEndCityCode, DateTime dtStartDate, DateTime dtEndDate, int numSeats)
        {
            List<FlightInfo> lstReturn = new List<FlightInfo>();
            List<Flight_DAL.Route> lstRoutes;
            lock (this)
            {
                lstRoutes = myFlightBLL.getFlightBLLInstance().getAvailableFlightBetweenCitiesOnDates(sStartCityCode, sEndCityCode, dtStartDate, dtEndDate, numSeats);
            }
            if (lstRoutes == null) return null;
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
                fInfo.FlightTime = r.FlightTime;
                lstReturn.Add(fInfo);
            }

            return lstReturn.ToArray();
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public bool checkIfAvailable(string sStartCityCode, string sEndCityCode, DateTime dtFlightDate, int iNumSeats)
        {
            //Route r = myFlightBLL.getFlightBLLInstance()
            throw new NotImplementedException();
        }
    }
}
