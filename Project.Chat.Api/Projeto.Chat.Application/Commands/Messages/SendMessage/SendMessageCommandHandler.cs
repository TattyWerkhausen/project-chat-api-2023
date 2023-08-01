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
        private readonly CreateNotificationCommand _createNotificationCommand;
        public SendMessageCommandHandler(IMessageRepository messageRepository, INotificationRepository notificationRepository, CreateNotificationCommand createNotificationCommand)
        {
            _messageRepository = messageRepository;
            _notificationRepository = notificationRepository;
            _createNotificationCommand = createNotificationCommand;
        }
        public async Task<Guid> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = request.ToMessage();
            var messageId = await _messageRepository.SendMessage(message);
            var notification = _createNotificationCommand.ToNotification();
            await _notificationRepository.CreateNotificationAsync(notification);

            return messageId;
        }
    }
}
