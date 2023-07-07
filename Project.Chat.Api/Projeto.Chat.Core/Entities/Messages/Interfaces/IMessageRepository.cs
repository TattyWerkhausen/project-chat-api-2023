using Projeto.Chat.Core.Entities.Users;

namespace Projeto.Chat.Core.Entities.Messages.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> SearchAllMessages(Guid idUserSend, Guid idUserReceive);
        Task<Guid> SendMessage(Message message);  
        Task<Guid> EditMessageAsync(Message message); 
        Task<Message> GetMessageById(Guid id);
    }
}
