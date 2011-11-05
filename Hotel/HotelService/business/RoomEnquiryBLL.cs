using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.business
{




    class RoomEnquiryBLL : HotelService.business.IRoomEnquiryBLL
    {
        /// <summary>
        /// Get roorms
        /// </summary>
        /// <returns></returns>
        public List<Room> getAllRooms()
        {

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                var query = from it in hotelDBEntities.Rooms.Include("RoomType")
                            where it.RoomType != null
                            select it;

                var list = query.ToList();
                foreach (var item in list)
                {
                    item.RoomTypeReference.Load();
                }

                return list;
            }
        }

        /// <summary>
        /// Check room
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
