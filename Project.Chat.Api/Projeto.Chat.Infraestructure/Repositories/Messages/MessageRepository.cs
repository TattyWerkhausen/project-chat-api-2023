using MySql.Data.MySqlClient;
using Projeto.Chat.Core.Entities.Messages;
using Projeto.Chat.Core.Entities.Messages.Interfaces;
using Projeto.Chat.Core.Entities.Users;
using Projeto.Chat.Infraestructure.DB;
using System.Xml.Linq;

namespace Projeto.Chat.Infraestructure.Repositories.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Database _database;
        public MessageRepository(Database database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Message>> SearchAllMessages(Guid idUserSend, Guid idUserReceive)
        {
            var connection = _database.ObterConnection();
            var query = "SELECT * FROM message Where IdUserSend = @IdUserSend AND IdUserReceive = @IdUserReceive";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdUserSend", idUserSend);
            command.Parameters.AddWithValue("@IdUserReceive", idUserReceive);


            MySqlDataReader reader = command.ExecuteReader();

            var messages = new List<Message>();

            while (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var idUserSendd = reader.GetGuid(reader.GetOrdinal("idUserSend"));
                var idUserReceivee = reader.GetGuid(reader.GetOrdinal("idUserReceive"));
                var content = reader.GetString(reader.GetOrdinal("content"));

                Message message = new Message(id, idUserSendd, idUserReceivee, content);
                messages.Add(message);
            }

            return messages;
        }

        public async Task<Guid> SendMessage(Message message)
        {
            var connection = _database.ObterConnection();

            var query = "INSERT INTO message (id, idUserSend, idUserReceive, content, date) VALUES (@Id, @IdUserSend, @IdUserReceive, @Content, @Date)";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", message.Id);
            command.Parameters.AddWithValue("@IdUserSend", message.IdUserSend);
            command.Parameters.AddWithValue("@IdUserReceive", message.IdUserReceive);
            command.Parameters.AddWithValue("@Content", message.Content);
            command.Parameters.AddWithValue("@Date", message.Date);
            command.ExecuteNonQuery();

            return message.Id;
        }
    }
}
