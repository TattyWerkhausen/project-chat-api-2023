using System.Data;

namespace Projeto.Chat.Core.Entities.Users
{
    public class User : Base
    {
        public string Name { get; private set; }

        public User(Guid id, string name, string email,string password) : base(id, email, password)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}
