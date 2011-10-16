using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.business
{
    class BLLFactory
    {


        private static Dictionary<Type, Object> classMap = new Dictionary<Type, object>();

        public static T getService<T>()
        {
            Type type = typeof(T);
            if (!classMap.ContainsKey(type))
            {
                classMap[type] = Activator.CreateInstance<T>();
            }

            return (T)classMap[type];

        }


        public static IReservationBLL getReservationBLL()
        {
            return (IReservationBLL)getService<ReservationBLL>();

        }


        public static IRoomEnquiryBLL getRoomEnquiryBLL()
        {
            return (IRoomEnquiryBLL)getService<RoomEnquiryBLL>();

        }

    }
}
