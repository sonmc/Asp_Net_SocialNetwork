﻿
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public string DoB { get; set; }
        public string Address { get; set; }
    }
}