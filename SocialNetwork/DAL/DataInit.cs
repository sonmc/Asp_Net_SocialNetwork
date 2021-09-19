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
                new User() {Id =9999, Age=20, DoB="2-9-1980",
                    Email="admin@gmail.com", FirstName="Admin",
                    LastName="Page", Gender=true, Password="letmein", Role=0, Address="TP.Hcm",
                    Avatar="https://upanh123.com/wp-content/uploads/2019/01/hinh-nen-girl-xinh-12.jpg",
                    BackGroundImg="https://salt.tikicdn.com/ts/tmp/9a/7e/db/bd7f0652d2a0a04f5f557e75048291b5.jpg",
                    IsActive=true,
                    Description="Success is the sum of small efforts, Reperted day in and day out"
                },
                new User() {Id =1, Age=20, DoB="2-9-1980",
                    Email="tannguyen@gmail.com", FirstName="Tân",
                    LastName="Nguyễn", Gender=true, Password="letmein", Role=1, Address="Tp Hcm",
                    Avatar="https://genk.mediacdn.vn/thumb_w/690/2019/7/8/1-15625474669018688730.jpg",
                    BackGroundImg="https://salt.tikicdn.com/ts/tmp/9a/7e/db/bd7f0652d2a0a04f5f557e75048291b5.jpg",
                    IsActive=true,
                    Description="A day without laughter is a day wasted."
                },
                    new User() {Id =2, Age=20, DoB="2-9-1989",
                    Email="ngoctrinh@gmail.com", FirstName="Ngọc",
                    LastName="Trinh", Gender=true, Password="letmein", Role=1, Address="Tp Hcm",
                    Avatar="https://genk.mediacdn.vn/thumb_w/690/2019/7/8/1-15625474669018688730.jpg",
                    BackGroundImg="https://salt.tikicdn.com/ts/tmp/9a/7e/db/bd7f0652d2a0a04f5f557e75048291b5.jpg",
                    IsActive=true,
                    Description="Hoa rơi cửa phật, vạn sự tuỳ duyên"
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
                    CategoryId=1, Image="", Title="Title", Time="", DateCreated= "9/11/2021 10:20:22", User= null, UserId=1, IsApprove = true
                },
                new New() {Id=1,Content="Content Image Type", ContentType=Common.IMAGE_TYPE, CategoryId=1,
                    Image="anhdep6.jpg",
                    Title="Title", Time="", DateCreated= "9/12/2021 10:20:22", User= null, UserId=1, IsApprove = true
                }
            };
            news.ForEach(n => context.News.Add(n));
            context.SaveChanges();
        }
    }
}