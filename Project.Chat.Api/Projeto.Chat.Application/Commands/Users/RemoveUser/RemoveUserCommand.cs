using MediatR;

namespace Projeto.Chat.Application.Commands.Users.RemoveUser
{
    public class RemoveUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
