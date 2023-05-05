using MediatR;

namespace Projeto.Chat.Application.Queries.Users.SearchAllUsers
{
    public class SearchAllUsersQuery : IRequest<IEnumerable<SearchAllUsersViewModel>>    
    {
        public string Name { get; set; }

        public SearchAllUsersQuery(string name)
        {
            Name = name;
        }
    }
}
