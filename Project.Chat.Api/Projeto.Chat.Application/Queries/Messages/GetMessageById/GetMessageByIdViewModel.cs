using Projeto.Chat.Core.Entities.Messages;

namespace Projeto.Chat.Application.Queries.Messages.GetMessageById
{
    public class GetMessageByIdViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUserSend { get; set; }
        public Guid IdUserReceive { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public GetMessageByIdViewModel(Guid id, Guid idUserSend, Guid idUserReceive, string content, DateTime date)
        {
            Id = id;
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
            Content = content;
            Date = date;
        }
        public static GetMessageByIdViewModel NewInstanceByMessage(Message message)
        {
            return new GetMessageByIdViewModel(message.Id, message.IdUserSend, message.IdUserReceive, message.Content, message.Date);
        }
    }
}
