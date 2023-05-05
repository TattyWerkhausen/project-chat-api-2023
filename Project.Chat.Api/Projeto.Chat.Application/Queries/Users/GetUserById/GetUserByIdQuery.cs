using MediatR;

namespace Projeto.Chat.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
