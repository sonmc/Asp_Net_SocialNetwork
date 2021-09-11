using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SocialNetwork.Entities;
using SocialNetwork.Constant;

namespace SocialNetwork.DAL
{
    public class DataInit : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            var users = new List<User>
            {
                new User() {Id =9999, Age=20, DoB="2-9-1990",
                    Email="admin@gmail.com", FirstName="Admin",
                    LastName="Page", Gender=true, Password="letmein", Role=0, Address="TP.Hcm",
                    Avatar="https://upanh123.com/wp-content/uploads/2019/01/hinh-nen-girl-xinh-12.jpg",
                    BackGroundImg="https://salt.tikicdn.com/ts/tmp/9a/7e/db/bd7f0652d2a0a04f5f557e75048291b5.jpg"
                },
                new User() {Id =9998, Age=20, DoB="2-9-1990",
                    Email="sonmc@gmail.com", FirstName="Son",
                    LastName="Mc", Gender=true, Password="letmein", Role=0, Address="HN",
                    Avatar="https://genk.mediacdn.vn/thumb_w/690/2019/7/8/1-15625474669018688730.jpg",
                    BackGroundImg="https://salt.tikicdn.com/ts/tmp/9a/7e/db/bd7f0652d2a0a04f5f557e75048291b5.jpg"
                }
            };
            users.ForEach(u => context.Users.Add(u));

            var categories = new List<Category>
            {
                new Category() {Id =1,Name="Thể Thao"},
                new Category() {Id =2,Name="Công nghệ"},
            };
            categories.ForEach(c => context.Categories.Add(c));

            var news = new List<New>
            {
                new New() {Id=1,Content="Content", ContentType=Common.TEXT_TYPE,
                    CategoryId=1, Image="", Title="Title", Time="One day ago", DateCreated=DateTime.Now.ToString(),User= null,UserId=9998

                },
                new New() {Id=1,Content="Content Image Type", ContentType=Common.IMAGE_TYPE,
                    CategoryId=1, Image="https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg", 
                    Title="Title", Time="One day ago", DateCreated=DateTime.Now.ToString(),User= null,UserId=9998

                }
            };
            news.ForEach(n => context.News.Add(n));

            context.SaveChanges();
        }
    }
}