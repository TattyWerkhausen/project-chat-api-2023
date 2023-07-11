using MediatR;

namespace Projeto.Chat.Application.Commands.Messages.RemoveMessage
{
    public class RemoveMessageCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
