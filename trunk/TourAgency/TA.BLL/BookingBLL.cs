using System.Linq;
using TA.DAL;

namespace TA.BLL
{
    public class BookingBLL
    {
        IBooking _booking = null;
        public BookingBLL()
        {
            _booking = DataAccessFactory.Instance.Booking;
        }

        public IQueryable<Booking> FindAllBookings()
        {
            return _booking.FindAllBookings();
        }

        public Booking GetBooking(int bookingId)
        {
            return _booking.GetBooking(bookingId);
        }

        public void AddBooking(Booking booking)
        {
            _booking.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _booking.UpateBooking(booking);
        }

        public void DeleteBooking(Booking booking)
        {
            _booking.DeleteBooking(booking);
        }
    }
}
