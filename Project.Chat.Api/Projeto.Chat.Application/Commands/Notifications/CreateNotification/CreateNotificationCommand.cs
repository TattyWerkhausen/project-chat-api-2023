using MediatR;
using Projeto.Chat.Core.Entities.Notifications;

namespace Projeto.Chat.Application.Commands.Notifications.CreateNotification
{
    public class CreateNotificationCommand : IRequest<Guid>
    {
        public Guid IdUserSend { get; set; }
        public Guid IdUserReceive { get; set; }

        public Notification ToNotification()
        {
            var notificationId = Guid.NewGuid();
            return new Notification(notificationId, IdUserSend, IdUserReceive);
        }
    }
}
