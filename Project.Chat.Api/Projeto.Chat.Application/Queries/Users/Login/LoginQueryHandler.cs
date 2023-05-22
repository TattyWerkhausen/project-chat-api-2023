using MediatR;
using Projeto.Chat.Core.Entities.Logins.Interfaces;

namespace Projeto.Chat.Application.Queries.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly ILoginRepository _loginRepository;

        public LoginQueryHandler(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _loginRepository.GetUserLoginAsync(request.Email, request.Password);
            if (user == null)
            {
                throw new ArgumentException("Usuario não existente");
            }
            else
            {
                return LoginViewModel.NewInstanceByUser(user);
            }
        }
    }
}
