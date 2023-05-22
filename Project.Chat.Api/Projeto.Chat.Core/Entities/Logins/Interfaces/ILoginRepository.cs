using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Core.Entities.Logins.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> GetUserLoginAsync(string email, string password);    
    }
}
