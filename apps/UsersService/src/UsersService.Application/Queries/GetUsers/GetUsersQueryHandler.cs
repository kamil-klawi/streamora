using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersService.Application.Dtos;
using UsersService.Domain.Common;
using UsersService.Domain.Entities;
using UsersService.Domain.Repositories;

namespace UsersService.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PageResult<UserDto>>
    {
        private readonly ILogger<GetUsersQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUsersQueryHandler(
            ILogger<GetUsersQueryHandler> logger,
            IMapper mapper,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<PageResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving all users");
            PageResult<User> user = await _usersRepository.GetUsers(request.PageSize, request.PageNumber);
            return _mapper.Map<PageResult<UserDto>>(user);
        }
    }
}
