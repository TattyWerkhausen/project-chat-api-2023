using MySql.Data.MySqlClient;
using Projeto.Chat.Core.Entities.Notifications;
using Projeto.Chat.Core.Entities.Notifications.Interface;
using Projeto.Chat.Infraestructure.DB;

namespace Projeto.Chat.Infraestructure.Repositories.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly Database _database;
        public NotificationRepository(Database database)
        {
            _database = database;
        }

        public async Task<Guid> CreateNotificationAsync(Notification notification)
        {

            var connection = _database.ObterConnection();

            var query = "INSERT INTO notification (id, idUserSend, idUserReceive, date, status) VALUES (@Id, @IdUserSend, @IdUserReceive, @Date, @Status)";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", notification.Id);
            command.Parameters.AddWithValue("@IdUserSend", notification.IdUserSend);
            command.Parameters.AddWithValue("@IdUserReceive", notification.IdUserReceive);
            command.Parameters.AddWithValue("@Date", notification.Date);
            command.Parameters.AddWithValue("@Status", notification.Status);
            command.ExecuteNonQuery();

            return notification.Id;
        }
    }
}
