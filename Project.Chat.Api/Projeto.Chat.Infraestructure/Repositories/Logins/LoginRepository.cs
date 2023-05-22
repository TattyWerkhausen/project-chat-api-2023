using MySql.Data.MySqlClient;
using Projeto.Chat.Core.Entities.Logins.Interfaces;
using Projeto.Chat.Core.Entities.Users;
using Projeto.Chat.Infraestructure.DB;

namespace Projeto.Chat.Infraestructure.Repositories.Logins
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Database _database;
        public LoginRepository(Database database)
        {
            _database = database;
        }
        public async Task<User> GetUserLoginAsync(string email, string password)
        {
            var connection = _database.ObterConnection();

            var query = "SELECT * FROM user WHERE email = @email AND password = @password";

            User user = null;

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var name = reader.GetString(reader.GetOrdinal("name"));
                var emaill = reader.GetString(reader.GetOrdinal("email"));
                var passwordd = reader.GetString(reader.GetOrdinal("password"));

                user = new User(id, name, emaill, passwordd);
            }
            reader.Close();

            return user;
        }
    }
}
