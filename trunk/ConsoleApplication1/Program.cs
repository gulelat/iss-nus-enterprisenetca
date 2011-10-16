using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();
            program.createReservation();
        }




        private void createRoomType()
        {


            RoomType roomType = RoomType.CreateRoomType(0, "2", 300, "Deluxe");

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {

                hotelDBEntities.RoomTypes.AddObject(roomType);
                hotelDBEntities.SaveChanges();


            }



        }



        private Guest createGuest()
        {


            Guest guest = Guest.CreateGuest(0,"Hans", "G19871030");

            //using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            //{

            //    hotelDBEntities.Guests.AddObject(guest);
            //    hotelDBEntities.SaveChanges();


            //}

            return guest;



        }

        private Room createRoom()
        {


            Room room = Room.CreateRoom(0,"2");
            room.RoomType = RoomType.CreateRoomType(0, "2", 600, "Studio");

            //using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            //{

            //    hotelDBEntities.Rooms.AddObject(room);
            //    hotelDBEntities.SaveChanges();


            //}

            return room;

        }



        private void createReservation()
        {


            RoomReservation reservation = RoomReservation.CreateRoomReservation(0,DateTime.Today, DateTime.Today+new TimeSpan(3,0,0,0), 2);
            reservation.Guest = createGuest();
            reservation.Room = createRoom();

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {

                hotelDBEntities.RoomReservations.AddObject(reservation);
                hotelDBEntities.SaveChanges();


            }

        }
    }
}
