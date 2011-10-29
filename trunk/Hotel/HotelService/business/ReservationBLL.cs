using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService

{


   
    class ReservationBLL : HotelService.business.IReservationBLL
    {

        public void makeReservation(String roomNo, String guestName, String passport, DateTime startDate, DateTime endDate, int numOfGuest)
        {
            RoomReservation reservtaion = RoomReservation.CreateRoomReservation(0, startDate, endDate, numOfGuest);
            

            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {

                reservtaion.Room = hotelDBEntities.Rooms.FirstOrDefault(room => room.RoomNo == roomNo);
               var theGuest = hotelDBEntities.Guests.FirstOrDefault(guest => guest.Name == guestName && guest.PassportNo == passport);
               if (theGuest == null)
               {

                   theGuest = Guest.CreateGuest(0,guestName,passport);

               }
               reservtaion.Guest = theGuest;
                hotelDBEntities.RoomReservations.AddObject(reservtaion);
                hotelDBEntities.SaveChanges();
            }

        }




        private void makePayment(Payment payment )
        {
           
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {

                hotelDBEntities.Payments.AddObject(payment);
                hotelDBEntities.SaveChanges();
            }

        }



        public void makeGroupReservation(String inputFile)
        {
            List<RoomReservation> reservtaions = parseDocument(inputFile);
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                foreach(RoomReservation reservation in reservtaions){
                    hotelDBEntities.RoomReservations.AddObject(reservation);

                }
                hotelDBEntities.SaveChanges();
            }

        }




        private List<RoomReservation> parseDocument(String inputFile)
        {

            return null;
        }

    }
}
