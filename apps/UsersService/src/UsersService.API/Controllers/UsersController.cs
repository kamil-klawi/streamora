using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersService.Application.Commands.CreateUser;
using UsersService.Application.Commands.DeleteUser;
using UsersService.Application.Commands.UpdateUser;
using UsersService.Application.Dtos;
using UsersService.Application.Queries.GetUserById;
using UsersService.Application.Queries.GetUsers;
using UsersService.Domain.Common;

namespace UsersService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand command)
        {
            Guid id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id }, null);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PageResult<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PageResult<UserDto>>> GetUsers([FromQuery] int sizeNumber = 10, [FromQuery] int pageNumber = 1)
        {
            PageResult<UserDto> users = await _mediator.Send(new GetUsersQuery(pageNumber, sizeNumber));
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid id)
        {
            UserDto user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetYourAccountDetails()
        {
            if (!TryGetUserIdFromToken(out Guid userId))
                return BadRequest("Invalid user ID in token.");

            UserDto user = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(user);
        }

        [Authorize]
        [HttpPatch("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateYourAccountDetails([FromBody] UpdateUserCommand command)
        {
            if (!TryGetUserIdFromToken(out Guid userId))
                return BadRequest("Invalid user ID in token.");

            await _mediator.Send(new UpdateUserCommand(userId, command.FirstName, command.LastName, command.Password));
            return Ok();
        }

        [Authorize]
        [HttpDelete("me")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteYourAccount() {
            if (!TryGetUserIdFromToken(out Guid userId))
                return BadRequest("Invalid user ID in token.");

            await _mediator.Send(new DeleteUserCommand(userId));
            return NoContent();
        }

        private bool TryGetUserIdFromToken(out Guid userId)
        {
            userId = Guid.Empty;
            Claim? userIdClaim = User.FindFirst("sub") ?? User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim is not null && Guid.TryParse(userIdClaim.Value, out userId);
        }
    }
}
