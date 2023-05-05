using MySql.Data.MySqlClient;

namespace Projeto.Chat.Infraestructure.DB
{
    public class Database : IDisposable
    {
        private readonly MySqlConnection _connection;

        public Database()
        {
            string connectionString = "server=localhost;database=projeto_chat;uid=root;pwd=132025;";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public MySqlConnection ObterConnection()
        {

            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}


