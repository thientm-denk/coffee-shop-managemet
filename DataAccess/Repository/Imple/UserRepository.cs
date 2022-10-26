using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user) => UserDAO.Instance.AddUser(user);

        public void DeleteUser(int userId) => UserDAO.Instance.Delete(userId);

        public int GetNextUserId()
        {
            return UserDAO.Instance.GetNextUserId();
        }

        public User GetUser(int userId)
        {
            return UserDAO.Instance.GetUser(userId);
        }

        public User GetUser(string name)
        {
            return UserDAO.Instance.GetUser(name);
        }

        public List<User> GetUsersList()
        {
            return UserDAO.Instance.GetUsersList();
        }

        public User Login(string name, string password)
        {
            return UserDAO.Instance.Login(name, password);
        }

        public List<User> SearchUser(string name)
        {
            return UserDAO.Instance.SearchUser(name);
        }

        public void UpdateUser(User user) => UserDAO.Instance.Update(user);
    }
}
