using MediatR;
using Projeto.Chat.Core.Entities.Messages.Interfaces;

namespace Projeto.Chat.Application.Commands.Messages.RemoveMessage
{
    public class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommand>
    {
        private readonly IMessageRepository _repository;
        public RemoveMessageCommandHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteMessageAsync(request.Id);
            return Unit.Value;
        }
    }
}
