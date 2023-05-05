using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Application.Queries.Users.GetUserById
{
    public class GetUserByIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public GetUserByIdViewModel(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static GetUserByIdViewModel NewInstanceByUser(User user)
        {
            return new GetUserByIdViewModel(user.Id, user.Name, user.Email);
        }
    }
}
