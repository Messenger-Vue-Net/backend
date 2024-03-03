
namespace Messenger.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime? Created { get; set; }

        public int? UserId {  get; set; }
        public User? User { get; set; }

        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
