using MediatR;
using Projeto.Chat.Core.Entities.Users.Interfaces;

namespace Projeto.Chat.Application.Commands.Users.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUserRepository _repository;
        public RemoveUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserAsync(request.Id);
            return Unit.Value;
        }
    }
}
