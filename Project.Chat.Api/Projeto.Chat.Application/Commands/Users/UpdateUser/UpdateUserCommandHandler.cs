using MediatR;
using Projeto.Chat.Core.Entities.Users.Interfaces;

namespace Projeto.Chat.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
           var user = await _repository.GetUserByIdAsync(request.Id);

            user.Update(request.Name);
            await _repository.UpdateUserAsync(user);
            
            return Unit.Value;  
        }
    }
}
