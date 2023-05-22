using MediatR;

namespace Projeto.Chat.Application.Queries.Users.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
