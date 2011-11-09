
namespace TA.DAL
{
    public class SessionFactory
    {
        private static TourAgencyModelContainer _entities;
        public static TourAgencyModelContainer buildIfNeeded()
        {
            if (_entities != null)
                return _entities;

            return ConfigureSessionFactory();
        }

        public static TourAgencyModelContainer Connection { get { return _entities; } }

        public static void CloseFactory()
        {
            if (_entities != null && _entities.Connection != null)
                _entities.Connection.Close();
            _entities = null;
        }

        private static TourAgencyModelContainer ConfigureSessionFactory()
        {
            _entities = new TourAgencyModelContainer();
            _entities.Connection.Open();
            return _entities;
        }
    }
}
