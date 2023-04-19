namespace Projeto.Chat.Core.Entities
{
    public class Base
    {
        public Guid Id { get; private set; }

        public Base(Guid id)
        {
            Id = id;
        }
    }
}
