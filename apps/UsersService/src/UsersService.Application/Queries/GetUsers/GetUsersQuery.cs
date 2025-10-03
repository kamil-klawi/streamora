using MediatR;
using UsersService.Application.Dtos;
using UsersService.Domain.Common;

namespace UsersService.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<PageResult<UserDto>>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public GetUsersQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
