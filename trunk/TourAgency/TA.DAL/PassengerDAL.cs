using System.Linq;

namespace TA.DAL
{
    public interface IPassenger
    {
        IQueryable<Passenger> FindAllPassengers();
        Passenger GetPassenger(int passengerId);
        void AddPassenger(Passenger passenger);
        void UpatePassenger(Passenger passenger);
        void DeletePassenger(Passenger passenger);
    }

    public class PassengerDAL : ObjectDAO, IPassenger
    {
        public IQueryable<Passenger> FindAllPassengers()
        {
            return TAEntities.Passengers;
        }

        public Passenger GetPassenger(int passengerId)
        {
            return TAEntities.Passengers.SingleOrDefault(m => m.Id == passengerId);
        }

        public void AddPassenger(Passenger passenger)
        {
            TAEntities.Passengers.AddObject(passenger);
            Save();
        }

        public void UpatePassenger(Passenger passenger)
        {
            TAEntities.Passengers.ApplyCurrentValues(passenger);
            Save();
        }

        public void DeletePassenger(Passenger passenger)
        {
            TAEntities.Passengers.DeleteObject(passenger);
            Save();
        }
    }
}
