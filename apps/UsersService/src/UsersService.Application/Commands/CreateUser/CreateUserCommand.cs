using MediatR;

namespace UsersService.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Nationality { get; private set; }
    }
}
