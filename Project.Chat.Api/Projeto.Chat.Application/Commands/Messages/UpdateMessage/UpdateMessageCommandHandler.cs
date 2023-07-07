using MediatR;
using Projeto.Chat.Core.Entities.Messages.Interfaces;

namespace Projeto.Chat.Application.Commands.Messages.UpdateMessage
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IMessageRepository _repository;
        public UpdateMessageCommandHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetMessageById(request.Id);

            message.Edit(request.Content);
            await _repository.EditMessageAsync(message);
            return Unit.Value;
        }
    }
}
