using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.business
{
    class HotelFacade
    {


        public List<Room> getAllRooms()
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


        public void makeSingleReservation(string roomNo, int guestId, DateTime startDtae, int duration, int noOfGuests)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();
            DateTime endDate = startDtae + new TimeSpan(duration, 0, 0, 0);
            reservationBLL.makeReservation(roomNo,guestId,startDtae,endDate,noOfGuests);

        }


        public void makeGroupReservation(string inputDocument)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();

            reservationBLL.makeGroupReservation(inputDocument);

        }


       
    }
}
