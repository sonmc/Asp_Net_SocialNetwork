using SocialNetwork.Constant;
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
            List<New> news = db.News.Where(n => n.CategoryId == categoryId && n.IsApprove).OrderBy(x => x.DateCreated).ToList();
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

        public New Create(int userId, string content, int categoryId, string img)
        {
            var obj = new New();
            obj.UserId = userId;
            obj.CategoryId = categoryId;
            obj.Content = content;
            obj.Image = img != "" ? img : "";
            obj.ContentType = img != "" ? Common.IMAGE_TYPE : Common.TEXT_TYPE;
            obj.DateCreated = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            obj.User = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            New dataAdded = db.News.Add(obj);
            db.SaveChanges();
            return dataAdded;
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