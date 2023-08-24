
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Pkix;
using Projeto.Chat.Application.Commands.Users.AddUser;
using Projeto.Chat.Application.Commands.Users.RemoveUser;
using Projeto.Chat.Application.Commands.Users.UpdateUser;
using Projeto.Chat.Application.Queries.Users.GetUserById;
using Projeto.Chat.Application.Queries.Users.GetUserByName;
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
        [HttpGet("{id}")]
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
        [HttpGet("searchName")]
        public async Task<IActionResult> SearchUserByName(string name)
        {
            var user = new SearchUserByNameQuery(name);
            var viewModel = await _mediator.Send(user);
            return Ok(viewModel);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUser)
        {
            await _mediator.Send(updateUser);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = new RemoveUserCommand();
            user.Id = id;
            await _mediator.Send(user);
            return Ok();
        }
    }
}
