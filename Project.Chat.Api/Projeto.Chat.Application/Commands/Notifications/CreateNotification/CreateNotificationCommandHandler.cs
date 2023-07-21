using MediatR;
using Projeto.Chat.Core.Entities.Notifications.Interface;

namespace Projeto.Chat.Application.Commands.Notifications.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _notificationRepository;
        public CreateNotificationCommandHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = request.ToNotification();
            var notificationId = await _notificationRepository.CreateNotificationAsync(notification);

            return notificationId;
        }
    }
}
