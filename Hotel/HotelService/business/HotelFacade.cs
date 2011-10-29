using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelService.datacontract;

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


        public void makeSingleReservation(ReservationRequest reservationRequest)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();
            DateTime endDate = reservationRequest.StartDate + new TimeSpan(reservationRequest.Duration, 0, 0, 0);
            reservationBLL.makeReservation(reservationRequest.RoomNo,reservationRequest.GuestName,reservationRequest.GuestPassport,  reservationRequest.StartDate, endDate, reservationRequest.NumOfGuest);

        }


        public void makeGroupReservation(string inputDocument)
        {
            IReservationBLL reservationBLL = BLLFactory.getReservationBLL();

            reservationBLL.makeGroupReservation(inputDocument);

        }


       
    }
}
