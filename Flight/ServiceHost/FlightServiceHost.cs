using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using FlightService;

namespace FlightServiceHost
{
    public class FlightService
    {
        static void Main(string[] args)
        {
            ServiceHost sh = null;

            try
            {
                sh = new ServiceHost(typeof(FlightService));
                sh.Open();

                Console.WriteLine("Press enter to stop server");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Exception");
            }
            finally
            {
                if (sh.State == CommunicationState.Opened) sh.Close();
            }

        }
    }
}
