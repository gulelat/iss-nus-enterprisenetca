using System;
namespace HotelService.business
{
    interface IRoomEnquiryBLL
    {
        bool checkRoomAvailability(string roomNo, DateTime startDate, DateTime endDate);
        System.Collections.Generic.List<HotelService.Room> getAllRooms();
    }
}
