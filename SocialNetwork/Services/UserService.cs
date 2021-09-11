using SocialNetwork.DAL;
using SocialNetwork.Models;

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
    }
}