using System.Linq;
using TA.DAL;

namespace TA.BLL
{
    public class PassengerBLL
    {
        IPassenger _passenger = null;
        public PassengerBLL()
        {
            _passenger = DataAccessFactory.Instance.Passenger;
        }

        public IQueryable<Passenger> FindAllPassengers()
        {
            return _passenger.FindAllPassengers();
        }

        public Passenger GetPassenger(int passengerId)
        {
            return _passenger.GetPassenger(passengerId);
        }

        public void AddPassenger(Passenger passenger)
        {
            _passenger.AddPassenger(passenger);
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _passenger.UpatePassenger(passenger);
        }

        public void DeletePassenger(Passenger passenger)
        {
            _passenger.DeletePassenger(passenger);
        }
    }
}
