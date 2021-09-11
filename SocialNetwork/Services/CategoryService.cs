using SocialNetwork.DAL;
using SocialNetwork.Entities;
using System.Collections.Generic;
using System.Linq;
namespace SocialNetwork.Services
{
    public class CategoryService
    {
        private DataContext db = new DataContext();

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }
    }
}