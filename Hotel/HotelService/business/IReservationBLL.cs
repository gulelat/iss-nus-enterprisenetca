using System;
namespace HotelService.business
{
    interface IReservationBLL
    {
        void makeGroupReservation(string inputFile);
         String makeReservation(String roomNo, String guestName, String passport, DateTime startDate, DateTime endDate, int numOfGuest, Payment payment);
  
    }
}
