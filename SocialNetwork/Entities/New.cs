
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Entities
{
    public class New
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentType { get; set; }
        public string Image { get; set; }
        public string DateCreated { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool IsApprove { get; set; }
        [NotMapped]
        public User User { get; set; }
        [NotMapped]
        public string Time { get; set; }
        [NotMapped]
        public Category Category { get; set; }
    }
}