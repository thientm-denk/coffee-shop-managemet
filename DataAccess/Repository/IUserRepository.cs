using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        public List<User> GetUsersList();
        public int GetNextUserId();
        public User Login(string name, string password);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
        public User GetUser(int userId);
        public User GetUser(string name);
        public List<User> SearchUser(string name);
    }
}
