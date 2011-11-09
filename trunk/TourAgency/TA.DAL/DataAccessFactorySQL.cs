
namespace TA.DAL
{
    public class DataAccessFactorySQL : DataAccessFactory
    {
        private IBooking _booking = new BookingDAL();
        private IPassenger _passenger = new PassengerDAL();
        private IUser _user = new UserDAL();
        private IPackage _package = new PackageDAL();

        public override IBooking Booking
        {
            get { return _booking; }
        }

        public override IPassenger Passenger
        {
            get { return _passenger; }
        }

        public override IPackage Package
        {
            get { return _package; }
        }

        public override IUser User
        {
            get { return _user; }
        }
    }
}
