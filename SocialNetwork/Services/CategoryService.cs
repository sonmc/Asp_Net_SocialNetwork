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
        public void Delete(int id)
        {
            Category cate = db.Categories.Find(id);
            db.Categories.Remove(cate);
            db.SaveChanges();
        }
        public void Create(string name)
        {
            Category ca = new Category();
            ca.Name = name;
            db.Categories.Add(ca);
            db.SaveChanges();
        }
    }
}