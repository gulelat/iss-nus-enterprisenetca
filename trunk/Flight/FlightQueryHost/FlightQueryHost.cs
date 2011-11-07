using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfFlightService;

namespace FlightServiceHost
{
    public class FlightService
    {
        static void Main(string[] args)
        {
            ServiceHost sh = null;

            try
            {
                sh = new ServiceHost(typeof(FlightQueryService));
                sh.Open();

                Console.WriteLine("Press enter to stop server");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception - "+e.Message);
            }
            finally
            {
                if (sh.State == CommunicationState.Opened) sh.Close();
            }

        }
    }
}
