using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using TA.Window.FBooking;
using TA.Window.FService;

namespace TA.Window
{
    public partial class frmFlightService : Form
    {
        static IFlightQueryService flightService = null;
        static FlightQueryCallback callback = null;
        public frmFlightService()
        {
            InitializeComponent();

            callback = new FlightQueryCallback(this);
            Initialise();

            flightService.getListOfDestinations();
        }

        private void Initialise()
        {
            InstanceContext context = new InstanceContext(callback);
            flightService = new FlightQueryServiceClient(context);
        }

        private bool IsFaultedState()
        {
            return ((FlightQueryServiceClient)flightService).State == CommunicationState.Faulted;
        }

        public void LoadFromCity()
        {
            cmbFrom.DisplayMember = "CityName";
            cmbFrom.ValueMember = "CityCode";

            DestinationInfo[] destinations = callback.destinationInfo;
            DestinationInfo[] newDestinations = new DestinationInfo[destinations.Length];

            for (int i = 0; i < destinations.Length; i++)
            {
                DestinationInfo d = new DestinationInfo();
                d.CityCode = destinations[i].CityCode;
                d.CityName = destinations[i].CityName;

                newDestinations[i] = d;
            }
            cmbFrom.DataSource = newDestinations;
            //ddFrom.DataBind();
        }

        public void LoadToCity()
        {
            cmbTo.DisplayMember = "CityName";
            cmbTo.ValueMember = "CityCode";
            DestinationInfo[] destinations = callback.destinationInfo;
            cmbTo.DataSource = destinations;
            //ddTo.DataBind();
        }

        public void LoadFlightInformation()
        {
            dgvFlightInformation.DataSource = callback.flightInfo;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string from = (string)cmbFrom.SelectedValue;
            string to = (string)cmbTo.SelectedValue;
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            if (IsFaultedState())
                Initialise();
            dgvFlightInformation.DataSource = null;
            flightService.getListOfAllAvailableFlightsBetweenCitiesOnDates(from, to, start, end);
        }

        private Dictionary<string, PassengerInfo> _dictPassengers = new Dictionary<string, PassengerInfo>();
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string passport = txtPassport.Text;
            DateTime expiry = dtpExpiry.Value;

            PassengerInfo passengerInfo = new PassengerInfo();
            passengerInfo.passengerName = name;
            passengerInfo.passportNo = passport;
            passengerInfo.expiryDate = expiry;

            _dictPassengers.Add(name, passengerInfo);

            lbPassenger.Items.Add(name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lbPassenger.SelectedIndex > -1 && lbPassenger.SelectedItem != null)
            {
                _dictPassengers.Remove((string)lbPassenger.SelectedItem);
                lbPassenger.Items.Remove(lbPassenger.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_dictPassengers.Count > 0)
            {
                DateTime flightDepartureDate = (DateTime)dgvFlightInformation["DepartureTime", dgvFlightInformation.CurrentRow.Index].Value;

                string from = (string)cmbFrom.SelectedValue;
                string to = (string)cmbTo.SelectedValue;

                PassengerInfo[] passengers = new PassengerInfo[_dictPassengers.Count];
                int i = 0;
                Dictionary<string, PassengerInfo>.Enumerator enumerator = _dictPassengers.GetEnumerator();
                while (enumerator.MoveNext())
                    passengers[i++] = enumerator.Current.Value;

                PaymentInfo payment = new PaymentInfo();
                payment.cardholdername = txtHolderName.Text;
                payment.cardname = txtCardName.Text;
                payment.cv2 = txtCardPin.Text;
                payment.expiryDate = dtpCardExpiry.Value;

                FBooking.FlightBookingServiceClient flightBooking = new FlightBookingServiceClient();

                try
                {
                    if (flightBooking.checkAvailability(from, to, flightDepartureDate, passengers.Length))
                    {
                        MessageBox.Show("Seats Available...");

                        if (flightBooking.makeReservation(from, to, flightDepartureDate, passengers, payment))
                            MessageBox.Show("Successfully reserved...");
                        else
                            MessageBox.Show("Reservation unsuccessful...");
                    }
                    else
                        MessageBox.Show("Seats Unavailable...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (flightBooking.State == CommunicationState.Faulted)
                        flightBooking = new FlightBookingServiceClient();

                    flightBooking.Close();
                }
            }
            else
            {
                MessageBox.Show("Please atleast one passenger...");
            }
        }
    }
}
