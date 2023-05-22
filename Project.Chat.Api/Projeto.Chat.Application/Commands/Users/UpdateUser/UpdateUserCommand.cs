using MediatR;

namespace Projeto.Chat.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
