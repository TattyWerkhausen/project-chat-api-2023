using MediatR;
using Projeto.Chat.Core.Entities.Users.Interfaces;

namespace Projeto.Chat.Application.Queries.Users.SearchAllUsers
{
    public class SearchAllUsersQueryHandler : IRequestHandler<SearchAllUsersQuery, IEnumerable<SearchAllUsersViewModel>>
    {
        private readonly IUserRepository _userRepository;
        public SearchAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        public async Task<IEnumerable<SearchAllUsersViewModel>> Handle(SearchAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync(request.Name);
            var userViewModel = users.Select(user => new SearchAllUsersViewModel(user.Id, user.Name, user.Email, user.Password)).ToList(); 
            return userViewModel;   
        }
    }
}
