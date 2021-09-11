 
using System.ComponentModel.DataAnnotations; 

namespace SocialNetwork.Models
{
    public class New
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentType { get; set; }
        public string Image { get; set; }
        public string DateCreated { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}