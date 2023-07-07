using MediatR;

namespace Projeto.Chat.Application.Commands.Messages.UpdateMessage
{
    public class UpdateMessageCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
