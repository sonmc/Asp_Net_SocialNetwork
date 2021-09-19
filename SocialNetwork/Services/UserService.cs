using SocialNetwork.Constant;
using SocialNetwork.DAL;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
namespace SocialNetwork.Services
{
    public class UserService
    {
        static DataContext db = new DataContext();
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
        public List<User> GetUser(int curentUserId)
        {
            var users = db.Users.Where(u => u.Role != 0 && u.Id != curentUserId && u.IsActive).ToList();
            var notFriend = IsNotFriend(users, curentUserId);
            return notFriend;
        }

        public static List<User> IsNotFriend(List<User> users, int curentUserId)
        {
            var notFriend = new List<User>();
            var listFriend = db.UserFriend.Where(x => (x.FromUserId == curentUserId || x.ToUserId == curentUserId) && (x.Status == 3 || x.Status == 2)).ToList();
            foreach (var item in users)
            {
                if (listFriend.Count == 0)
                {
                    notFriend.Add(item);
                }
                else
                {
                    foreach (var friend in listFriend)
                    {
                        if (friend.FromUserId != item.Id && friend.ToUserId != item.Id && friend.Status < 3)
                        {
                            notFriend.Add(item);
                        }
                    }
                }
            }
            return notFriend;
        }
        public List<User> GetAllUser(int curentUserId)
        {
            return db.Users.Where(u => u.Role != 0 && u.Id != curentUserId).ToList();
        }
        public Friend AddFriend(int fromId, int idFriend)
        {
            var friend = new Friend();
            friend.FromUserId = fromId;
            friend.ToUserId = idFriend;
            friend.Status = 2;
            var friendAdded = db.UserFriend.Add(friend);
            db.SaveChanges();
            return friendAdded;
        }
        public List<User> GetFriendsRequest(int toUserId)
        {
            var listFriendRequest = new List<User>();
            var friends = db.UserFriend.Where(x => x.ToUserId == toUserId && x.Status == 2).ToList();
            foreach (var item in friends)
            {
                var user = db.Users.Where(x => x.Id == item.FromUserId).FirstOrDefault();
                listFriendRequest.Add(user);
            }
            return listFriendRequest;
        }
        public List<Friend> GetFriends(int currentUserId)
        {
            var friends = db.UserFriend.Where(x => (x.FromUserId == currentUserId || x.ToUserId == currentUserId) && x.Status == 3).ToList();
            foreach (var item in friends)
            {
                var userId = item.ToUserId == currentUserId ? item.FromUserId : item.ToUserId;
                item.UserFriend = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            }
            return friends;
        }
        public bool AcceptFriend(int fromId, int myId)
        {
            bool isAccepted = false;
            try
            {
                var friendPending = db.UserFriend.Where(x => x.FromUserId == fromId && x.ToUserId == myId).FirstOrDefault();
                friendPending.Status = 3;
                db.Entry(friendPending).State = EntityState.Modified;
                db.SaveChanges();
                isAccepted = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isAccepted;
        }
        public bool UpdateUser(User user)
        {
            bool isUpdated = false;
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex) { }
            return isUpdated;
        }

        public User Create(User user)
        {
            User added = db.Users.Add(user);
            db.SaveChanges();
            return added;
        }
        public bool RemoveFriendRequest(int fromUserId, int toUserId)
        {
            bool isRemoved = false;
            try
            {
                Friend fn = db.UserFriend.Where(x => x.FromUserId == fromUserId && x.ToUserId == toUserId).FirstOrDefault();
                db.UserFriend.Remove(fn);
                isRemoved = true;
            }
            catch (Exception)
            {
                isRemoved = false;
            }
            return isRemoved;
        }
        public List<SharePost> GetPostShared(int currentId)
        {
            var listPostShared = db.SharePosts.Where(x => x.ToUserId == currentId).ToList();
            foreach (var item in listPostShared)
            { 
                item.UserShared = db.Users.Where(x => x.Id == item.FromUserId).FirstOrDefault();
                CultureInfo culture = new CultureInfo("en-US");
                var datetimeCreated = Convert.ToDateTime(DateTime.Now, culture);
                item.Time = Common.GetTime(datetimeCreated); 
            }
            return listPostShared;
        }
        public bool SharePostToFriend(int fromId, int toId, int postId)
        {
            bool isShared = false;
            try
            {
                var sharePost = new SharePost();
                sharePost.FromUserId = fromId;
                sharePost.ToUserId = toId;
                sharePost.NewId = postId;
                sharePost.DateCreated = DateTime.Now.ToString();
                db.SharePosts.Add(sharePost);
                db.SaveChanges();
                isShared = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isShared;
        }
    }
}