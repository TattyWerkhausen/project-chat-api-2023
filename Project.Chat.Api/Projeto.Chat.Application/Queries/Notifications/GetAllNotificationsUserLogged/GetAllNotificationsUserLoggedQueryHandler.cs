using MediatR;
using Projeto.Chat.Core.Entities.Notifications;
using Projeto.Chat.Core.Entities.Notifications.Interface;

namespace Projeto.Chat.Application.Queries.Notifications.GetAllNotificationsUserLogged
{
    public class GetAllNotificationsUserLoggedQueryHandler : IRequestHandler<GetAllNotificationsUserLoggedQuery, IEnumerable<GetAllNotificationsUserLoggedViewModel>>
    {
        private readonly INotificationRepository _notificationRepository;
        public GetAllNotificationsUserLoggedQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<IEnumerable<GetAllNotificationsUserLoggedViewModel>> Handle(GetAllNotificationsUserLoggedQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Notification> notifications = await _notificationRepository.GetAllNotificationsAsync(request.IdUserSend);

            // lista de notificaçõesVm que percorre cada notificação atravez do select e para cada item e cria uma conversão para viewModel
            // esta conversão é necessaria pois não posso usar diretamente a entidade de dominio de notificação, entao crio uma forma de visualização(View Model)
            // Conceito de Presenters da arquitetura limpa

            List<GetAllNotificationsUserLoggedViewModel> notificationsViewModel = notifications.Select(notification => new GetAllNotificationsUserLoggedViewModel(notification.Id, notification.IdUserSend, notification.IdUserReceive,
               notification.Date, notification.Status)).ToList();

            return notificationsViewModel;
        }
    }
}
