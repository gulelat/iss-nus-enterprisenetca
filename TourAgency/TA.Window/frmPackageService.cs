using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.BLL;
using TA.DAL;
using TA.Window.FBooking;
using System.ServiceModel;
using TA.Window.FService;
using TA.Window.HService;
using TA.Window.HBooking;
using System.Transactions;

namespace TA.Window
{
    public partial class frmPackageService : Form
    {
        private PackageBLL _packageBll = null;
        private BookingBLL _bookingBLL = null;
        private PassengerBLL _passengerBLL = null;

        IFlightQueryService flightService = null;
        FlightQueryCallback1 callback = null;

        HotelInfoEnquiryServiceClient _hotelEnquiry = null;
        HotelDataInfoUpdateClient _hotelBooking = null;

        public frmPackageService()
        {
            InitializeComponent();

            _packageBll = new PackageBLL();
            _bookingBLL = new BookingBLL();
            _passengerBLL = new PassengerBLL();

            LoadPackages();

            callback = new FlightQueryCallback1(this);
            Initialise();

            _hotelBooking = new HotelDataInfoUpdateClient();
            _hotelEnquiry = new HotelInfoEnquiryServiceClient();
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

        private void LoadPackages()
        {
            cmbPackage.DisplayMember = "Name";
            cmbPackage.ValueMember = "Code";
            cmbPackage.Items.AddRange(_packageBll.FindAllPackages().ToArray());
        }

        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPackageDetails.DataSource = null;
            dgvFlightInformation.DataSource = null;
            dgvRoomDetails.DataSource = null;

            Package packageInfo = (Package)((ComboBox)sender).SelectedItem;
            dgvPackageDetails.DataSource = _packageBll.FindAllPackages().Where(m => m.Code == packageInfo.Code);

            //load flight
            if (IsFaultedState())
                Initialise();
            flightService.getListOfAllFlightsBetweenCities(packageInfo.From, packageInfo.To);

            //load hotel
            dgvRoomDetails.DataSource = _hotelEnquiry.getAllRoomInfos();
        }

        public void LoadFlightInformation()
        {
            dgvFlightInformation.DataSource = callback.flightInfo;
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

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (_dictPassengers.Count > 0)
            {
                Package packageInfo = (Package)cmbPackage.SelectedItem;

                string from = packageInfo.From;
                string to = packageInfo.To;
                DateTime flightDepartureDate = (DateTime)dgvFlightInformation["DepartureTime", dgvFlightInformation.CurrentRow.Index].Value;
                DateTime end = flightDepartureDate.AddDays(packageInfo.Duration);

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

                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        if (flightBooking.checkAvailability(from, to, flightDepartureDate, passengers.Length))
                        {
                            MessageBox.Show("Flight Seats Available...");

                            if (flightBooking.makeReservation(from, to, flightDepartureDate, passengers, payment))
                                MessageBox.Show("Flight Reservation Successful...");
                            else
                                throw new Exception("Flight Reservation unsuccessful...");
                        }
                        else
                            throw new Exception("Seats Unavailable...");

                        string cartType = txtCardType.Text;
                        string guestAccount = txtGuestAccount.Text;
                        string guestName = txtGuestName.Text;
                        string guestPassport = txtGuestPassport.Text;
                        int duration = packageInfo.Duration;
                        int numberOfGuest = _dictPassengers.Count;
                        string roomNo = (string)dgvRoomDetails["roomNo", dgvRoomDetails.CurrentRow.Index].Value;
                        if (_hotelBooking.checkRoomAvailability(roomNo, dtpStartDate.Value.ToString(), duration))
                        {
                            MessageBox.Show("Hotel Room Available...");

                            MessageBox.Show(_hotelBooking.makeRoomReservation(cartType, guestAccount, guestName, guestPassport, duration, numberOfGuest, roomNo, dtpStartDate.Value.ToString(), ""));
                        }
                        else
                            throw new Exception("Hotel Room Unavailable..");

                        ts.Complete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
