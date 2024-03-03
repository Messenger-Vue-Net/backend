using Messenger.Domain.Entities;

namespace Messenger.Application.Interface
{
    public interface IMessengerService
    {
        Task<List<Message>> GetMessages(Guid group);
        Task<bool> SendMessage(string text);
    }
}
