using MediatR;
using Projeto.Chat.Core.Entities.Users;
using Projeto.Chat.Core.Entities.Users.Interfaces;

namespace Projeto.Chat.Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUserRepository _repository;
        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = request.ToUser();

            await ValidationUser(currentUser);
            var userId = await _repository.AddUserAsync(currentUser);
            return userId;

        }

        private async Task ValidationUser(User currentUser)
        {
            var user = await _repository.SearchEmailUserAsync(currentUser.Email);
            if (user.Email == user.Email)
            {
                throw new Exception("ja tem um usuario com esse email");
            }
            var userName = user.Name == null;
            var userEmail = user.Email == null;
            var userPassword = user.Password == null;
            if (userName || userEmail || userPassword)
            {
                throw new Exception("Dados invalidos, por favor preencha os dados para cadastro!");
            }
        }
    }
}
