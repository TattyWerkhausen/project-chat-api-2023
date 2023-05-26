using MediatR;

namespace Projeto.Chat.Application.Queries.Users.GetUserByName
{
    public class SearchUserByNameQuery : IRequest<SearchUserByNameViewModel>
    {
        public string Name { get; set; }

        public SearchUserByNameQuery(string name)
        {
            Name = name;
        }
    }
}
