using System.Linq;

namespace TA.DAL
{
    public interface IBooking
    {
        IQueryable<Booking> FindAllBookings();
        Booking GetBooking(int bookingId);
        void AddBooking(Booking booking);
        void UpateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }

    public class BookingDAL : ObjectDAO, IBooking
    {
        public IQueryable<Booking> FindAllBookings()
        {
            return TAEntities.Bookings;
        }

        public Booking GetBooking(int bookingId)
        {
            return TAEntities.Bookings.SingleOrDefault(m => m.BookingCode == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            TAEntities.Bookings.AddObject(booking);
            Save();
        }

        public void UpateBooking(Booking booking)
        {
            TAEntities.Bookings.ApplyCurrentValues(booking);
            Save();
        }

        public void DeleteBooking(Booking booking)
        {
            TAEntities.Bookings.DeleteObject(booking);
            Save();
        }
    }
}
