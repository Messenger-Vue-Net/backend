using Messenger.Application.Interface;
using Messenger.Domain.Entities;
using Messenger.Presentence.Context;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Application.UseCases
{
    public class MessengerService : IMessengerService
    {
        private readonly ApplicationDbContext _db;

        public MessengerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Message>> GetMessages(Guid group)
        {
            var messages = await _db.Messages.Where(x => x.GroupId == group).Include(u => u.User).ToListAsync();
            return messages;
        }

        public Task<bool> SendMessage(string text)
        {
            throw new NotImplementedException();
        }
    }
}
