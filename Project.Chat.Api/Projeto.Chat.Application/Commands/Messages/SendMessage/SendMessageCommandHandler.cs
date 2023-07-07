using MediatR;
using Projeto.Chat.Core.Entities.Messages.Interfaces;

namespace Projeto.Chat.Application.Commands.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Guid>
    {
        private readonly IMessageRepository _messageRepository;
        public SendMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<Guid> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = request.ToMessage();
            var messageId = await _messageRepository.SendMessage(message);
           
            return messageId;
        }
    }
}
