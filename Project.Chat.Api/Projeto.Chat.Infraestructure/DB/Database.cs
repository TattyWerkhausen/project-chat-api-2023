using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Projeto.Chat.Infraestructure.DB
{
    public class Database : IDisposable
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            string connectionString = "Server=DESKTOP-E462BBA\\SQLEXPRESS;Database=chat2023;Integrated Security=true;TrustServerCertificate=True";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlConnection ObterConnection()
        {

            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}


