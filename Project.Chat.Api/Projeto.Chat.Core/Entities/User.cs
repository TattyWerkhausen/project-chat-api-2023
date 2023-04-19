namespace Projeto.Chat.Core.Entities
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
    }
}
