using System.Data;

namespace Projeto.Chat.Core.Entities.Users
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public User(Guid id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}
