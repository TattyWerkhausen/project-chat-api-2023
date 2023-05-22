using Projeto.Chat.Application.Queries.Users.GetUserById;
using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Application.Queries.Users.Login
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public static LoginViewModel NewInstanceByUser(User user)
        {
            return new LoginViewModel(user.Id, user.Name, user.Email, user.Password);
        }
    }
}
