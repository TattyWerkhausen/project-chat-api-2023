using Projeto.Chat.Core.Entities.Messages;

namespace Projeto.Chat.Application.Queries.Messages.SearchAllMessages
{
    public class SearchAllMessagesViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUserSend { get; set; }
        public Guid IdUserReceive { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public SearchAllMessagesViewModel(Guid id, Guid idUserSend, Guid idUserReceive, string content, DateTime date)
        {
            Id = id;
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
            Content = content;
            Date = date;
        }
        public static SearchAllMessagesViewModel NewInstanceByMessage(Message message)
        {
            //preenchimento dos dados pedidos no construtor
            return new SearchAllMessagesViewModel(message.Id, message.IdUserSend, message.IdUserReceive, message.Content, message.Date);
        }
    }
}
