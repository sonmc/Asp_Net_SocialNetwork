using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SocialNetwork.Models;

namespace SocialNetwork.DAL
{
    public class DataInit : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            var users = new List<User>
            {
                new User() {Id =9999,Age=20,DoB="2-9-1990",
                    Email="admin@gmail.com", FirstName="Admin",
                    LastName="Page", Gender=true,Password="letmein",Role=0, Address="TP.Hcm" }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}