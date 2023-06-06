using MediatR;
using Projeto.Chat.Core.Entities.Messages;

namespace Projeto.Chat.Application.Commands.Messages.SendMessage
{
    public class SendMessageCommand : IRequest<Guid>
    {
        public Guid IdUserSend { get; set; }
        public Guid IdUserReceive { get; set; }
        public string Content { get; set; }

        public Message ToMessage()
        {
            var messageId = Guid.NewGuid();
            return new Message(messageId, IdUserSend, IdUserReceive, Content);
        }
    }
}
