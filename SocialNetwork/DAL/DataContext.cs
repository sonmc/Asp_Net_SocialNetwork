
using SocialNetwork.Entities;
using System.Data.Entity; 

namespace SocialNetwork.DAL
{
    public class DataContext :DbContext
    {
        public DataContext(): base("DataContext") { } 
        public DbSet<New> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> UserFriend { get; set; }

    }

}