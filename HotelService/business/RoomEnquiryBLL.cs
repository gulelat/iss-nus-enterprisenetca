using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.business




    class RoomEnquiryBLL : HotelService.business.IRoomEnquiryBLL
    {
        public List<Room> getAllRooms()
        {


            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                List<Room> rooms = hotelDBEntities.Rooms.ToList();

                return rooms;
            }
        }





        public Boolean checkRoomAvailability(String roomNo, DateTime startDate, DateTime endDate)
        {
            Boolean isAvailable = true;
            List<RoomReservation> reservations = null;

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                var result = hotelDBEntities.RoomReservations.Include("Room").Where(reservation => reservation.Room.RoomNo == roomNo);

                reservations = result.ToList();
            }


            if (reservations != null)
            {


                foreach (RoomReservation reservation in reservations)
                {
                    if (DateTime.Compare(reservation.StartDate, endDate) > 0 || DateTime.Compare(reservation.EndDate, startDate) < 0)
                    {

                        isAvailable = false;
                        break;
                    }
                }



            }

            return isAvailable;
        }
    }
}
