using Microsoft.Data.SqlClient;
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
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", notification.Id);
            command.Parameters.AddWithValue("@IdUserSend", notification.IdUserSend);
            command.Parameters.AddWithValue("@IdUserReceive", notification.IdUserReceive);
            command.Parameters.AddWithValue("@Date", notification.Date);
            command.Parameters.AddWithValue("@Status", notification.Status);
            command.ExecuteNonQuery();

            return notification.Id;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync(Guid idUserLogged)
        {
            var connection = _database.ObterConnection();

            var query = "SELECT * FROM notification where idUserSend = @idUserLogged";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@idUserLogged", idUserLogged);

            SqlDataReader reader = command.ExecuteReader();

            var notifications = new List<Notification>();

            while (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var idUserSendd = reader.GetGuid(reader.GetOrdinal("idUserSend"));
                var idUserReceivee = reader.GetGuid(reader.GetOrdinal("idUserReceive"));


                Notification notification = new Notification(id, idUserSendd, idUserReceivee);
                notifications.Add(notification);
            }

            return notifications;
        }
    }
}
