using MediatR;

namespace Projeto.Chat.Application.Queries.Messages.SearchAllMessages
{
    public class SearchAllMessagesQuery :IRequest<IEnumerable<SearchAllMessagesViewModel>>
    {
        public Guid IdUserSend { get; set; }    
        public Guid IdUserReceive { get; set; }

        public SearchAllMessagesQuery(Guid idUserSend, Guid idUserReceive)
        {
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
        }
    }
}
