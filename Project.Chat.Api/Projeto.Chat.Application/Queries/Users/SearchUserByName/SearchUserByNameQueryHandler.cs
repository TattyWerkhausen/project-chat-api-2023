using MediatR;
using Projeto.Chat.Core.Entities.Users.Interfaces;

namespace Projeto.Chat.Application.Queries.Users.GetUserByName
{
    public class SearchUserByNameQueryHandler : IRequestHandler<SearchUserByNameQuery, SearchUserByNameViewModel>
    {
        private readonly IUserRepository _userRepository;
        public SearchUserByNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<SearchUserByNameViewModel> Handle(SearchUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SearchUserByNameAsync(request.Name);
            return SearchUserByNameViewModel.NewInstanceByUser(user);
        }
    }
}
