using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Window.HService;
using TA.Window.HBooking;

namespace TA.Window
{
    public partial class frmHotelService : Form
    {
        HotelInfoEnquiryServiceClient _hotelEnquiry = null;
        HotelDataInfoUpdateClient _hotelBooking = null;

        public frmHotelService()
        {
            InitializeComponent();

            _hotelBooking = new HotelDataInfoUpdateClient();
            _hotelEnquiry = new HotelInfoEnquiryServiceClient();

            LoadRoomInfo();
        }

        private void LoadRoomInfo()
        {
            dgvRoomDetails.DataSource = null;
            RoomInfo[] roomsInfo = _hotelEnquiry.getAllRoomInfos();
            dgvRoomDetails.DataSource = roomsInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadRoomInfo();
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            string cartType = txtCardType.Text;
            string guestAccount = txtGuestAccount.Text;
            string guestName = txtGuestName.Text;
            string guestPassport = txtGuestPassport.Text;
            int duration = (int)nudDuration.Value;
            int numberOfGuest = (int)nudGuestNumber.Value;
            string roomNo = (string)dgvRoomDetails["roomNo", dgvRoomDetails.CurrentRow.Index].Value;
            if (_hotelBooking.checkRoomAvailability(roomNo, dtpStartDate.Value.ToString(), duration))
            {
                MessageBox.Show("Room Available...");

                MessageBox.Show(_hotelBooking.makeRoomReservation(cartType, guestAccount, guestName, guestPassport, duration, numberOfGuest, roomNo, dtpStartDate.Value.ToString(), ""));
            }
            else
                MessageBox.Show("Room Unavailable..");
        }
    }
}
