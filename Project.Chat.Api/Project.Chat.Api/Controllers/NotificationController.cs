using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Chat.Application.Commands.Notifications.CreateNotification;

namespace Project.Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationCommand createNotification)
        {
            var notificationId = await _mediator.Send(createNotification);
            return Ok(notificationId);
        }
    }
}
