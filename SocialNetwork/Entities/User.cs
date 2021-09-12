
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public string DoB { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string BackGroundImg { get; set; }
    }
}