namespace Projeto.Chat.Application.Commands.User
{
    public class AddUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public AddUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
