using SocialNetwork.Models; 
using System.Data.Entity; 

namespace SocialNetwork.DAL
{
    public class DataContext :DbContext
    {
        public DataContext(): base("DataContext") { } 
        public DbSet<New> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }

}