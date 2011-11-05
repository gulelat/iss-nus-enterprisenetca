using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelService;
using HotelService.business;
using ConsoleApplication1.ServiceReference1;
using ConsoleApplication1.ServiceReference2;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Room> list;
            //using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            //{
            //    var query = from it in hotelDBEntities.Rooms
            //                where it.RoomType != null
            //                select it;

            //    list = query.ToList();

            //    foreach (var item in list)
            //    {
            //        item.RoomTypeReference.Load();
            //    }

            //}
            //return;

            //Program program = new Program();
            //program.createReservation();
            var client = new HotelDataInfoUpdateClient();

            try
            {
               // RoomInfo[] roomInfos = client.getAllRoomInfos();
                //bool avail = client.checkRoomAvailability("1001","5/11/2011",1);

                ReservationRequest request = new ReservationRequest();
                request.CardType = "VISA";
                request.Duration = 2;
                request.GuestAccount = "12345678";
                request.GuestName = "Tan Geok";
                request.GuestPassport = "G19881030";
                request.NumOfGuest = 2;
                request.RoomNo = "1001";
                request.StartDate = "5/11/2011";
                request.TotalCharge = "600";
                String response = client.makeRoomReservation(request.CardType, request.GuestAccount, request.GuestName, request.GuestPassport, request.Duration, request.NumOfGuest, request.RoomNo, request.StartDate, request.TotalCharge);
                // createRoom();
                client.Close();
                Console.WriteLine(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                client.Abort();
            }

            //HotelFacade facade = new HotelFacade();

            // List<Room> rooms = facade.getAllRooms();

            //  Console.WriteLine(rooms.Count);

            Console.ReadLine();
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


            Guest guest = Guest.CreateGuest(0, "Hans", "G19871030");

            //using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            //{

            //    hotelDBEntities.Guests.AddObject(guest);
            //    hotelDBEntities.SaveChanges();


            //}

            return guest;



        }

        private static Room createRoom()
        {


            Room room = Room.CreateRoom(0, "1002");
            room.RoomType = RoomType.CreateRoomType(0, "2", 600, "Executive");

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {

                hotelDBEntities.Rooms.AddObject(room);
                hotelDBEntities.SaveChanges();


            }

            return room;

        }



        private void createReservation()
        {


            RoomReservation reservation = RoomReservation.CreateRoomReservation(0, DateTime.Today, DateTime.Today + new TimeSpan(3, 0, 0, 0), 2);
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
