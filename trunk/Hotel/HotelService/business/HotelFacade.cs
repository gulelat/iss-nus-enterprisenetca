using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.business
{
   public  class HotelFacade
    {


        public  List<Room> getAllRooms()
        {
            IRoomEnquiryBLL roomEnquiryBLL = BLLFactory.getRoomEnquiryBLL();
            return roomEnquiryBLL.getAllRooms();
        }


        public Boolean checkRoomAvailability(string roomNo, DateTime startDtae, int duration)
        {
            IRoomEnquiryBLL roomEnquiryBLL = BLLFactory.getRoomEnquiryBLL();

            DateTime endDate = startDtae + new TimeSpan(duration, 0, 0, 0);
            return roomEnquiryBLL.checkRoomAvailability(roomNo, startDtae,endDate);
        }


        public string makeReservation(String roomNo, String guestName, String guestPass, DateTime startDate, int duration, int noOfGuests, Payment payment)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();
            DateTime endDate = startDate + new TimeSpan(duration, 0, 0, 0);
            return  reservationBLL.makeReservation(roomNo, guestName, guestPass, startDate, endDate, noOfGuests, payment);

        }


        public void makeGroupReservation(string inputDocument)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();

            reservationBLL.makeGroupReservation(inputDocument);

        }


       
    }
}
