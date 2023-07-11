using MediatR;

namespace Projeto.Chat.Application.Queries.Messages.GetMessageById
{
    public class GetMessageByIdQuery:IRequest<GetMessageByIdViewModel>  
    {
        public Guid Id { get; set; }

        public GetMessageByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
