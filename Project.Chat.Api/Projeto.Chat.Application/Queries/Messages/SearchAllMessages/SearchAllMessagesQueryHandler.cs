using MediatR;
using Projeto.Chat.Core.Entities.Messages.Interfaces;

namespace Projeto.Chat.Application.Queries.Messages.SearchAllMessages
{
    public class SearchAllMessagesQueryHandler : IRequestHandler<SearchAllMessagesQuery, IEnumerable<SearchAllMessagesViewModel>>
    {
        private readonly IMessageRepository _messageRepository;
        public SearchAllMessagesQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository; 
        }
        public async Task<IEnumerable<SearchAllMessagesViewModel>> Handle(SearchAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var mensagens = await _messageRepository.SearchAllMessages(request.IdUserSend, request.IdUserReceive);
            var messagesViewModel = new List<SearchAllMessagesViewModel>();
            foreach (var message in mensagens)
            {
                var messageViewModel = SearchAllMessagesViewModel.NewInstanceByMessage(message);
                messagesViewModel.Add(messageViewModel);
            }
            return messagesViewModel;
        }
    }
}
