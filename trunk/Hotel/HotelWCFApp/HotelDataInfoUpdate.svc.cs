using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataInfo;
using HotelService;
using HotelService.business;


namespace HotelWCFApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelDataInfoUpdate" in code, svc and config file together.
    public class HotelDataInfoUpdate : IHotelDataInfoUpdate
    {
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


        public ReservationResponse makeRoomReservation(ReservationRequest request)
        {

            try
            {
                HotelFacade hotelFacade = new HotelFacade();

                DateTime startDate = DateTime.Parse(request.StartDate);
                Payment payment = new Payment();
                payment.CardType = request.CardType;
                payment.GuestAccount = request.GuestAccount;
                payment.TotalCharge = request.TotalCharge;
                payment.CardType = request.CardType;

                String responseCode =  hotelFacade.makeReservation(request.RoomNo,request.GuestName,request.GuestPassport,startDate,request.Duration,request.NumOfGuest, payment);
                ReservationResponse response = new ReservationResponse();
                response.responseCode = responseCode;
                return response;
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
    }
}
