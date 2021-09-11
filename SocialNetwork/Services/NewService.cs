using SocialNetwork.DAL;
using SocialNetwork.Entities; 
using System.Collections.Generic;
using System.Linq;
namespace SocialNetwork.Services
{
    public class NewService
    {
        private DataContext db = new DataContext();
        public List<New> GetByCategoryId(int? categoryId)
        {
            List<New> news = db.News.Where(n => n.CategoryId == categoryId).ToList();

            return news;
        }
    }
}