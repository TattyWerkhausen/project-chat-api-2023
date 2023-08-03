using MediatR;
using Projeto.Chat.Application.Commands.Notifications.CreateNotification;
using Projeto.Chat.Core.Entities.Messages.Interfaces;
using Projeto.Chat.Core.Entities.Notifications.Interface;

namespace Projeto.Chat.Application.Commands.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Guid>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMediator _mediator;
        public SendMessageCommandHandler(IMessageRepository messageRepository, INotificationRepository notificationRepository, IMediator mediator)
        {
            _messageRepository = messageRepository;
            _notificationRepository = notificationRepository;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = request.ToMessage();
            var messageId = await _messageRepository.SendMessage(message);

            var createNotificationCommand = new CreateNotificationCommand() { IdUserReceive = request.IdUserReceive, IdUserSend = request.IdUserSend };
            await _mediator.Send(createNotificationCommand);

            return messageId;
        }
    }
}
