using MediatR;

namespace UsersService.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; private set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
