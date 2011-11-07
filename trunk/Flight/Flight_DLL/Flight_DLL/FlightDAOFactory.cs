using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* DAL factory to obtain the reference to the DAL implementation class. 
 * Assuming a simple case of single interface implementing all the retrieval. 
 */
namespace Flight_DAL
{
    public class FlightDAOFactory
    {
        private static FlightDAOFactory dbInstance;
        private static IFlightDAL flightDALInstance = null;

        //Make sure the class is a singleton
        private FlightDAOFactory()
        {
        }
        public static FlightDAOFactory getInstance()
        {
            if (dbInstance == null)
                dbInstance = new FlightDAOFactory();
            return dbInstance;
        }

        //Change the function to include difference database handler.. 
        public IFlightDAL getFlightDALInstance()
        {
            if(flightDALInstance == null) return new FlightDAL();
            return flightDALInstance;
        }
    }
}
