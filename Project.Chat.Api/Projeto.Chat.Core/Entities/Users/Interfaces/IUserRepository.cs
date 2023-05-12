namespace Projeto.Chat.Core.Entities.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync(string name);
        Task<Guid> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
