 

namespace SocialNetwork.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public bool Status { get; set; }
    }
}