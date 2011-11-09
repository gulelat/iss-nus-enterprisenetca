using System.Linq;

namespace TA.DAL
{
    public interface IUser
    {
        IQueryable<User> FindAllUsers();
        User GetUser(string userId);
        void AddUser(User user);
        void UpateUser(User user);
        void DeleteUser(User user);
    }

    public class UserDAL : ObjectDAO, IUser
    {
        public IQueryable<User> FindAllUsers()
        {
            return TAEntities.Users;
        }

        public User GetUser(string userId)
        {
            return TAEntities.Users.SingleOrDefault(m => m.UserId.Equals(userId));
        }

        public void AddUser(User user)
        {
            TAEntities.Users.AddObject(user);
            Save();
        }

        public void UpateUser(User user)
        {
            TAEntities.Users.ApplyCurrentValues(user);
            Save();
        }

        public void DeleteUser(User user)
        {
            TAEntities.Users.DeleteObject(user);
            Save();
        }
    }
}
