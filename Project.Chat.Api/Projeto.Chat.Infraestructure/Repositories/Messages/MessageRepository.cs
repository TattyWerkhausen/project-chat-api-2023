using Microsoft.Data.SqlClient;
using Projeto.Chat.Core.Entities.Messages;
using Projeto.Chat.Core.Entities.Messages.Interfaces;
using Projeto.Chat.Infraestructure.DB;

namespace Projeto.Chat.Infraestructure.Repositories.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Database _database;
        public MessageRepository(Database database)
        {
            _database = database;
        }

        public async Task DeleteMessageAsync(Guid id)
        {
            var connection = _database.ObterConnection();

            string query = "DELETE FROM message WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        public async Task<Guid> EditMessageAsync(Message message)
        {
            var connection = _database.ObterConnection();
            var query = "UPDATE message SET Content = @Content WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Content", message.Content);
            command.Parameters.AddWithValue("@Id", message.Id);

            command.ExecuteNonQuery();
            return message.Id;
        }

        public async Task<Message> GetMessageById(Guid id)
        {
            var connection = _database.ObterConnection();
            var query = "SELECT * FROM message WHERE id = @id";

            Message result = null;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                var idUserSend = reader.GetGuid(reader.GetOrdinal("idUserSend"));
                var idUserReceive = reader.GetGuid(reader.GetOrdinal("idUserReceive"));
                var content = reader.GetString(reader.GetOrdinal("content"));

                result = new Message(id, idUserSend, idUserReceive, content);
            }
            reader.Close();
            return result;
        }

        public async Task<IEnumerable<Message>> SearchAllMessages(Guid idUserLogged, Guid idUserSelected)
        {
            var connection = _database.ObterConnection();
            // comparando para busca ususario que enviou e usuario qye recebeu
            var query = "SELECT * FROM message Where (idUserSend = @idUserLogged AND idUserReceive = @idUserSelected) " +
                // comparando para busca usuario que enviou para mim, e o que enviei para ele
                "OR (idUserReceive = @idUserLogged AND idUserSend = @idUserSelected) ORDER BY Date ASC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@idUserLogged", idUserLogged);
            command.Parameters.AddWithValue("@idUserSelected", idUserSelected);


            SqlDataReader reader = command.ExecuteReader();

            var messages = new List<Message>();

            while (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var idUserSendd = reader.GetGuid(reader.GetOrdinal("idUserSend"));
                var idUserReceivee = reader.GetGuid(reader.GetOrdinal("idUserReceive"));
                // var content = reader.GetString(reader.GetOrdinal("content"));
                var contentOrdinal = reader.GetOrdinal("content");
                var contentReader = reader.GetTextReader(contentOrdinal);
                var content = contentReader.ReadToEnd();

                Message message = new Message(id, idUserSendd, idUserReceivee, content);
                messages.Add(message);
            }

            return messages;
        }

        public async Task<Guid> SendMessage(Message message)
        {
            var connection = _database.ObterConnection();

            var query = "INSERT INTO message (id, idUserSend, idUserReceive, content, date) VALUES (@Id, @IdUserSend, @IdUserReceive, @Content, @Date)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", message.Id.ToByteArray());
            command.Parameters.AddWithValue("@IdUserSend", message.IdUserSend);
            command.Parameters.AddWithValue("@IdUserReceive", message.IdUserReceive);
            command.Parameters.AddWithValue("@Content", message.Content);
            command.Parameters.AddWithValue("@Date", message.Date);
            command.ExecuteNonQuery();

            return message.Id;
        }
    }
}
