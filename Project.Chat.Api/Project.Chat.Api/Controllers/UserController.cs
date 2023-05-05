
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Chat.Application.Commands.Users;
using Projeto.Chat.Application.Queries.Users.GetUserById;
using Projeto.Chat.Application.Queries.Users.SearchAllUsers;

namespace Project.Chat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand addUserCommand)
        {
            var id = await _mediator.Send(addUserCommand);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }
        [HttpGet("users")]
        public async Task<IActionResult> SearchUsers(string? name = "")
        {
            var users = await _mediator.Send(new SearchAllUsersQuery(name));
            return Ok(users);
        }
    }
}
