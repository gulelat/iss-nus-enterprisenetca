using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataInfo;
using HotelService;
using HotelService.business;



namespace HotelWCFApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class HotelInfoEnquiryService : IHotelInfoEnquiryService
    {

       public List<RoomInfo> getAllRoomInfos()
        {
            try
            {
                var hotelFacade = new HotelFacade();
                List<Room> rooms = hotelFacade.getAllRooms();
                if (rooms != null && rooms.Count > 0)
                {
                    List<RoomInfo> roomInfos = new List<RoomInfo>();

                    foreach (Room room in rooms)
                    {
                        RoomInfo roomInfo = new RoomInfo();
                        roomInfo.roomNo = room.RoomNo;
                        roomInfo.roomType = room.RoomType.Name;
                        roomInfo.dailyCharge = room.RoomType.DailyCharge.ToString();
                        roomInfo.capacity = room.RoomType.Capacity;
                        roomInfos.Add(roomInfo);
                    }

                    return roomInfos;
                }
                else
                {
                    throw new Exception("No room Available");
                }
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }


       public Boolean checkRoomAvailability(string roomNo, string startDateStr, int duration)
       {
           try
           {
               HotelFacade hotelFacade = new HotelFacade();

               DateTime startDate = DateTime.Parse(startDateStr);

               return hotelFacade.checkRoomAvailability(roomNo, startDate, duration);
           }
           catch (Exception e)
           {
               throw new FaultException<Exception>(e);
           }
       }

    }
}
