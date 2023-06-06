using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Core.Entities.Messages
{
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid IdUserSend { get; private set; }
        public Guid IdUserReceive { get; private set; }
        public string Content { get; private set; }
        public DateTime Date { get; private set; }
        public User UserSend { get; private set; }
        public User UserReceive { get; private set; }

        public Message(Guid id, Guid idUserSend, Guid idUserReceive, string content)
        {
            Id = id;
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
            Content = content;
            Date = DateTime.Now;
        }
        public void Edit(string content)
        {
            Content = content;  
        }
    }
}
