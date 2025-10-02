using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersService.Application.Dtos;
using UsersService.Domain.Repositories;

namespace UsersService.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ILogger<GetUserByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdQueryHandler(
            ILogger<GetUserByIdQueryHandler> logger,
            IMapper mapper,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving user by Id {Id}", request.Id);
            var user = await _usersRepository.GetUserById(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
