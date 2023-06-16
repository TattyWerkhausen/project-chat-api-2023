namespace Projeto.Chat.Core.Entities.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> SearchUserByNameAsync(string name);
        Task<User> SearchEmailUserAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync(string name);
        Task<Guid> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
