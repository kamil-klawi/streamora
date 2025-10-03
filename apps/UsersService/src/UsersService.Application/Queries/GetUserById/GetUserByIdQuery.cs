using MediatR;
using UsersService.Application.Dtos;

namespace UsersService.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; private set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
