

namespace Projeto.Chat.Application.Queries.Notifications.GetAllNotificationsUserLogged
{
    public class GetAllNotificationsUserLoggedViewModel
    {
        public Guid Id { get; private set; }
        public Guid IdUserSend { get; private set; }
        public Guid IdUserReceive { get; private set; }
        public DateTime Date { get; private set; }
        public bool Status { get; private set; }

        // construtor criado para 
        public GetAllNotificationsUserLoggedViewModel(Guid id, Guid idUserSend, Guid idUserReceive, DateTime date, bool status)
        {
            Id = id;
            IdUserSend = idUserSend;
            IdUserReceive = idUserReceive;
            Date = date;
            Status = status;
        }
    }
}
