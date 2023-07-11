using MediatR;
using Projeto.Chat.Core.Entities.Messages.Interfaces;

namespace Projeto.Chat.Application.Queries.Messages.GetMessageById
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, GetMessageByIdViewModel>
    {
        private readonly IMessageRepository _repository;
        public GetMessageByIdQueryHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMessageByIdViewModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetMessageById(request.Id);
            return GetMessageByIdViewModel.NewInstanceByMessage(message);
        }
    }
}
