using SocialNetwork.DAL;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace SocialNetwork.Services
{
    public class NewService
    {
        private DataContext db = new DataContext();
        public List<New> GetByCategoryId(int? categoryId)
        {
            List<New> news = db.News.Where(n => n.CategoryId == categoryId && n.IsApprove).ToList();
            return news;
        }
        public List<New> Get()
        {
            var news = db.News.OrderBy(n => n.IsApprove).ToList();
            foreach (var item in news)
            {
                item.Category = db.Categories.Where(c => c.Id == item.CategoryId).FirstOrDefault();
                item.User = db.Users.Where(u => u.Id == item.UserId).FirstOrDefault();
            }
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

        public New GetById(int id)
        {
            var newObj = db.News.Where(x => x.Id == id).FirstOrDefault();
            return newObj;
        }

        public New Create(int userId, string content)
        {
            var obj = new New();
            obj.UserId = userId;
            obj.Content = content;
            obj.DateCreated = DateTime.Now.ToString();
            obj.User = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            db.News.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool UpdateNew(New newObj)
        {
            bool isUpdated = false;
            try
            {
                db.Entry(newObj).State = EntityState.Modified;
                db.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex) { }
            return isUpdated;
        }
    }
}