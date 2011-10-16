using System;
namespace HotelService.business
{
    interface IReservationBLL
    {
        void makeGroupReservation(string inputFile);
        void makeReservation(string roomNo, int guestId, DateTime startDate, DateTime endDate, int numOfGuest);
    }
}
