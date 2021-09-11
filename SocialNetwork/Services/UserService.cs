using SocialNetwork.DAL;
using SocialNetwork.Entities;
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
    }
}