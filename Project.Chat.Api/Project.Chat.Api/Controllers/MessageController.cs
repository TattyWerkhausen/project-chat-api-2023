using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Chat.Application.Commands.Messages.RemoveMessage;
using Projeto.Chat.Application.Commands.Messages.SendMessage;
using Projeto.Chat.Application.Commands.Messages.UpdateMessage;
using Projeto.Chat.Application.Commands.Users.RemoveUser;
using Projeto.Chat.Application.Queries.Messages.GetMessageById;
using Projeto.Chat.Application.Queries.Messages.SearchAllMessages;

namespace Project.Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommand sendMessage)
        {
            var messageId = await _mediator.Send(sendMessage);
            return Ok(messageId);
        }
        [HttpGet("{idUserSend}/{idUserReceive}")]
        public async Task<IActionResult> AllMessages(Guid idUserSend, Guid idUserReceive)
        {
            var messages = await _mediator.Send(new SearchAllMessagesQuery(idUserSend, idUserReceive));
            return Ok(messages);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageCommand updateMessage)
        {
            await _mediator.Send(updateMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(Guid id)
        {
            var query = new GetMessageByIdQuery(id);
            var viewModel = await _mediator.Send(query);    
            return Ok(viewModel);   
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            var message = new RemoveMessageCommand();
            message.Id = id;
            await _mediator.Send(message);
            return Ok();
        }
    }
}
