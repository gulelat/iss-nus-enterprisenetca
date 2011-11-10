using System.Windows.Forms;
using TA.Window.FService;

namespace TA.Window
{
    class FlightQueryCallback : IFlightQueryServiceCallback
    {
        public string[] flightIDs = null;
        public DestinationInfo[] destinationInfo = null;
        public FlightInfo[] flightInfo = null;

        private frmFlightService _flightService = null;

        public FlightQueryCallback(frmFlightService flightService)
        {
            this._flightService = flightService;
        }

        public void OnFlightIDQueryCallback(string[] flights)
        {
            flightIDs = flights;
            MessageBox.Show("Loaded Flights...");
        }

        public void onDestinationQueryCallback(DestinationInfo[] destinations)
        {
            destinationInfo = destinations;
            MessageBox.Show("Loaded Destinations...");
            _flightService.LoadFromCity();
            _flightService.LoadToCity();
        }

        public void onAvailabilityQueryCallback(bool status)
        {
            if (status)
                MessageBox.Show("Seats are available... Book now. ");
            else
                MessageBox.Show("Seats requested are not available, enquire for another day");
        }

        public void onFlightInfoQueryCallback(FlightInfo[] flights)
        {
            flightInfo = flights;
            MessageBox.Show("Loaded Flight Information...");

            _flightService.LoadFlightInformation();
        }
    }

    class FlightQueryCallback1 : IFlightQueryServiceCallback
    {
        public string[] flightIDs = null;
        public DestinationInfo[] destinationInfo = null;
        public FlightInfo[] flightInfo = null;

        private frmPackageService _packageService = null;

        public FlightQueryCallback1(frmPackageService packageService)
        {
            this._packageService = packageService;
        }

        public void OnFlightIDQueryCallback(string[] flights)
        {
            flightIDs = flights;
            MessageBox.Show("Loaded Flights...");
        }

        public void onDestinationQueryCallback(DestinationInfo[] destinations)
        {
            destinationInfo = destinations;
            MessageBox.Show("Loaded Destinations...");
        }

        public void onAvailabilityQueryCallback(bool status)
        {
            if (status)
                MessageBox.Show("Seats are available... Book now. ");
            else
                MessageBox.Show("Seats requested are not available, enquire for another day");
        }

        public void onFlightInfoQueryCallback(FlightInfo[] flights)
        {
            flightInfo = flights;
            MessageBox.Show("Loaded Flight Information...");
            _packageService.LoadFlightInformation();
        }
    }
}
