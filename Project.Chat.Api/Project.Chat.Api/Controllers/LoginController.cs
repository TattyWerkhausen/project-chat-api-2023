using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Chat.Application.Queries.Users.Login;

namespace Project.Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery loginQuery)
        {
            var user = await _mediator.Send(loginQuery);
            return Ok(user);
        }
    }
}
