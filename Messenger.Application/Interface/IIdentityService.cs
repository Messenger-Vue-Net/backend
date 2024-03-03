namespace Messenger.Application.Interface
{
    public interface IIdentityService
    {
        Task<string> Login(string login, string password);
    }
}
