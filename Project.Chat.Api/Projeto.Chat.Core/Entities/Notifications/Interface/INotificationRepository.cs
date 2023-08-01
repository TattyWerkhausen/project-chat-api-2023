namespace Projeto.Chat.Core.Entities.Notifications.Interface
{
    public interface INotificationRepository
    {
        Task<Guid> CreateNotificationAsync(Notification notification);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync(Guid idUserLogged); 
    }
}
