using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static object instanceLook = new object();

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        // Get default user from appsettings
        private User GetDefaultMember()
        {
            User Default = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string name = config["account:defaultAccount:Email"];
                string password = config["account:defaultAccount:Password"];
                Default = new User
                {
                    UserId = 0,
                    Name = name,
                    Password = password,
                    Role = "admin",
                };
            }
            return Default;
        }

        public List<User> GetUsersList()
        {
            List<User> users = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                users = context.Users.ToList();
                // Add Default User
                users = users.Append(GetDefaultMember()).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public User Login(string name, string password)
        {
            List<User> users = GetUsersList();
            foreach(User u in users)
            {
                if (u.Name != null && u.Password!= null)
                {
                    if (u.Name.ToLower().Equals(name.ToLower()) && u.Password.Equals(password))
                    {
                        return u;
                    }
                }
            }
            
            return null;
        }

        public User GetUser(int userId)
        {
            User user = null;

            try
            {
                var context = new CoffeeShopContext();
                user = context.Users.SingleOrDefault(u => u.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public User GetUser(string userName)
        {
            User user = null;

            try
            {
                var context = new CoffeeShopContext();
                user = context.Users.SingleOrDefault(u => u.Name.Equals(userName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public int GetNextUserId()
        {
            int nextUserId = -1;

            try
            {
                var context = new CoffeeShopContext();
                nextUserId = context.Users.Max(u => u.UserId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nextUserId;
        }
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new Exception("User is undefined!!");
            }
            try
            {
                if (GetUser(user.UserId) == null && GetUser(user.Name) == null)
                {
                    var context = new CoffeeShopContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("User is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new Exception("User is undefined!!");
            }
            try
            {
                User u = GetUser(user.UserId);
                if (u != null)
                {
                    var context = new CoffeeShopContext();
                    context.Users.Update(u);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("User does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Delete(int userId)
        {
            try
            {
                User user = GetUser(userId);
                if (user != null)
                {
                    var context = new CoffeeShopContext();
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("User does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> SearchUser(string name)
        {
            List<User> searchResult = null;

            try
            {
                var context = new CoffeeShopContext();
                searchResult = context.Users.Where(u => u.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return searchResult;
        }

    }
}
