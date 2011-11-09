

namespace TA.DAL
{
    public abstract class DataAccessFactory
    {
        private static DataAccessFactory _dataAccessFactory = null;
        private static object sLock = new object();

        public static DataAccessFactory Instance
        {
            get
            {
                if (_dataAccessFactory == null)
                {
                    lock (sLock)
                    {
                        if (_dataAccessFactory == null)
                            _dataAccessFactory = new DataAccessFactorySQL();
                    }
                }
                return _dataAccessFactory;
            }
        }

        public abstract IBooking Booking { get; }
        public abstract IPassenger Passenger { get; }
        public abstract IPackage Package { get; }
        public abstract IUser User { get; }
    }
}
