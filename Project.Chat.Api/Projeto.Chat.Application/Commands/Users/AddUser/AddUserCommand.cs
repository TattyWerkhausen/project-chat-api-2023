using MediatR;
using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        /* public AddUserCommand(string name, string email)
         {
             Name = name;
             Email = email;
         }*/
        public User ToUser()
        {
            var userId = Guid.NewGuid();
            return new User(userId, Name, Email, Password);
        }
    }
}
