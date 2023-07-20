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
            var existentUser = await _repository.SearchEmailUserAsync(currentUser.Email);
            if (existentUser != null)
            {
                throw new Exception("ja tem um usuario com esse email");
            }
            var userName = currentUser.Name == null;
            var userEmail = currentUser.Email == null;
            var userPassword = currentUser.Password == null;
            if (userName || userEmail || userPassword)
            {
                throw new Exception("Dados invalidos, por favor preencha os dados para cadastro!");
            }
        }
    }
}
