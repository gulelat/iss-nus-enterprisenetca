using System;
namespace HotelService.business
{
    interface IReservationBLL
    {
        void makeGroupReservation(string inputFile);
        public void makeReservation(String roomNo, String guestName, String passport, DateTime startDate, DateTime endDate, int numOfGuest);
  
    }
}
