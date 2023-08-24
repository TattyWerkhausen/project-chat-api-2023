using Microsoft.Data.SqlClient;
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

            string query = "INSERT INTO [user] (id, name, email, password) VALUES (@Id, @Name, @Email, @Password)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.ExecuteNonQuery();

            return user.Id;
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var connection = _database.ObterConnection();

            string query = "DELETE FROM [user] WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(string name = null)
        {
            var connection = _database.ObterConnection();
            var query = "SELECT Id, Name, Email, Password FROM [user]";

            if (!string.IsNullOrEmpty(name))
            {
                query += " WHERE LOWER(Name) LIKE @Name";
            }


            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(name))
            {
                command.Parameters.AddWithValue("@Name", "%" + name.ToLower() + "%");
            }

            SqlDataReader reader = command.ExecuteReader();

            var users = new List<User>();

            while (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var namee = reader.GetString(reader.GetOrdinal("name"));
                var email = reader.GetString(reader.GetOrdinal("email"));
                var password = reader.GetString(reader.GetOrdinal("password"));



                User user = new User(id, namee, email, password);
                users.Add(user);
            }

            return users;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var connection = _database.ObterConnection();

            string query = "SELECT * FROM [user] WHERE id = @id";

            User result = null;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                var name = reader.GetString(reader.GetOrdinal("name"));
                var email = reader.GetString(reader.GetOrdinal("email"));
                var password = reader.GetString(reader.GetOrdinal("password"));

                result = new User(id, name, email, password);
            }
            reader.Close();
            return result;
        }

        public async Task<User> SearchEmailUserAsync(string email)
        {
            var connection = _database.ObterConnection();

            string query = "SELECT * FROM [user] WHERE LOWER(Email) LIKE @Email";

            User result = null;

            SqlCommand command = new SqlCommand(query, connection);
            if (!string.IsNullOrEmpty(email))
            {
                command.Parameters.AddWithValue("@Email", "%" + email.ToLower() + "%");
            }

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var name = reader.GetString(reader.GetOrdinal("name"));
                var emaill = reader.GetString(reader.GetOrdinal("email"));
                var password = reader.GetString(reader.GetOrdinal("password"));

                result = new User(id, name, emaill, password);
            }
            reader.Close();
            return result;
        }

        public async Task<User> SearchUserByNameAsync(string name)
        {
            var connection = _database.ObterConnection();

            string query = "SELECT * FROM [user] WHERE LOWER(Name) LIKE @Name";

            User result = null;

            SqlCommand command = new SqlCommand(query, connection);
            if (!string.IsNullOrEmpty(name))
            {
                command.Parameters.AddWithValue("@Name", "%" + name.ToLower() + "%");
            }

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var namee = reader.GetString(reader.GetOrdinal("name"));
                var email = reader.GetString(reader.GetOrdinal("email"));
                var password = reader.GetString(reader.GetOrdinal("password"));

                result = new User(id, namee, email, password);
            }
            reader.Close();
            return result;
        }

        public async Task<Guid> UpdateUserAsync(User user)
        {
            var connection = _database.ObterConnection();
            string updateQuery = "UPDATE [user] SET Name = @Name WHERE Id = @Id";

            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);


            command.ExecuteNonQuery();

            return user.Id;
        }
    }
}
