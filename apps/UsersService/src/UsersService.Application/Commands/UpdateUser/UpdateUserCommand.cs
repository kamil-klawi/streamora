using MediatR;

namespace UsersService.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public UpdateUserCommand(Guid id, string password, string firstName, string lastName)
        {
            Id = id;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
