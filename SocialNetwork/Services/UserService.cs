using SocialNetwork.DAL;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace SocialNetwork.Services
{
    public class UserService
    {
        private DataContext db = new DataContext();
        public User Login(string email, string pwd)
        {
            foreach (var item in db.Users)
            {
                if (item.Email == email && item.Password == pwd)
                {
                    return item;
                }
            }
            return null;
        }
        public User GetUserById(int id)
        {
            User user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }
        public List<User> Get()
        {
            return db.Users.Where(u => u.Role != 0).ToList();
        }
        public bool UpdateUser(User user)
        {
            bool isUpdated = false;
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex) {  }
            return isUpdated;
        }

        public User Create(User user)
        {
            User added = db.Users.Add(user);
            db.SaveChanges();
            return added;
        }
        
    }
}