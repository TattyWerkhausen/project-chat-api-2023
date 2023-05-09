using MySql.Data.MySqlClient;
using Projeto.Chat.Core.Entities.Users;
using Projeto.Chat.Core.Entities.Users.Interfaces;
using Projeto.Chat.Infraestructure.DB;

namespace Projeto.Chat.Infraestructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly Database _database;
        public UserRepository(Database database)
        {
            _database = database;
        }
        public async Task<Guid> AddUserAsync(User user)
        {
            var connection = _database.ObterConnection();

            string query = "INSERT INTO user (id, name, email) VALUES (@Id, @Name, @Email)";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.ExecuteNonQuery();

            return user.Id;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(string name = null)
        {
            var connection = _database.ObterConnection();
            var query = "SELECT Id, Name, Email FROM user";

            if (!string.IsNullOrEmpty(name))
            {
                query += " WHERE Name = @name";
                //query += "WHERE UPPER(Name) LIKE UPPER(@name)";
            }


            MySqlCommand command = new MySqlCommand(query, connection);

            if (!string.IsNullOrEmpty(name))
            {
                command.Parameters.AddWithValue("@name", name);
            }

            MySqlDataReader reader = command.ExecuteReader();

            var users = new List<User>();

            while (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var namee = reader.GetString(reader.GetOrdinal("name"));
                var email = reader.GetString(reader.GetOrdinal("email"));

                User user = new User(id, namee, email);
                users.Add(user);
            }

            return users;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var connection = _database.ObterConnection();

            string query = "SELECT * FROM user WHERE id = @id";

            User result = null;

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                var email = reader.GetString(reader.GetOrdinal("email"));
                var name = reader.GetString(reader.GetOrdinal("name"));
                result = new User(id, name, email);
            }
            return result;
        }

        public async Task<Guid> UpdateUserAsync(User user)
        {
            var connection = _database.ObterConnection();
            string updateQuery = "UPDATE user SET Name = @Name, Email = @Email WHERE Id = @Id";

            MySqlCommand command = new MySqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Id", user.Id);
            command.ExecuteNonQuery();

            return user.Id;
        }
    }
}
