using MediatR;

namespace Projeto.Chat.Application.Queries.Notifications.GetAllNotificationsUserLogged
{
    public class GetAllNotificationsUserLoggedQuery:IRequest<IEnumerable<GetAllNotificationsUserLoggedViewModel>>
    {
        public Guid IdUserSend { get; set; }

        //Construtor criado para poder passar parametro na query chamada na controller
        public GetAllNotificationsUserLoggedQuery(Guid idUserSend)
        {
            IdUserSend = idUserSend;
        }
    }
}
