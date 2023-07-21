using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Core.Entities.Notifications
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public Guid IdUserSend { get; private set; }
        public Guid IdUserReceive { get; private set; }
        public DateTime Date { get; private set; }
        public User User { get; private set; }
        public bool Status { get; private set; }

        public Notification(Guid id, Guid idUserSend, Guid idUserReceive)
        {
            Id = id;
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
            Date = DateTime.Now;
            Status = false;
        }
    }
}
