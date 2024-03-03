namespace Messenger.Domain.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
    }
}