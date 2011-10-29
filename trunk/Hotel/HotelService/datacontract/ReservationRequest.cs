using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelService.datacontract
{
    class ReservationRequest
    {

        public String RoomNo { get; set; }
        public String GuestName { get; set; }
        public String GuestPassport { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int NumOfGuest { get; set; }

    }
}
