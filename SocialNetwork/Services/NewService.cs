using SocialNetwork.DAL;
using SocialNetwork.Entities;
using System;
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
        public bool Delete(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = db.News.Where(x => x.Id == id).FirstOrDefault();
                db.News.Remove(record);
                db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex) { }
            return isDeleted;
        }
    }
}