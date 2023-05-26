using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Application.Queries.Users.GetUserByName
{
    public class SearchUserByNameViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SearchUserByNameViewModel(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public static SearchUserByNameViewModel NewInstanceByUser(User user)
        {
            return new SearchUserByNameViewModel(user.Id, user.Name, user.Email, user.Password);
        }
    }
}
