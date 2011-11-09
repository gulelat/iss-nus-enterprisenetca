using System.Linq;
using TA.DAL;

namespace TA.BLL
{
    public class UserBLL
    {
        IUser _user = null;
        public UserBLL()
        {
            _user = DataAccessFactory.Instance.User;
        }

        public IQueryable<User> FindAllUsers()
        {
            return _user.FindAllUsers();
        }

        public User GetUser(string userId)
        {
            return _user.GetUser(userId);
        }

        public void AddUser(User user)
        {
            _user.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _user.UpateUser(user);
        }

        public void DeleteUser(User user)
        {
            _user.DeleteUser(user);
        }
    }
}
