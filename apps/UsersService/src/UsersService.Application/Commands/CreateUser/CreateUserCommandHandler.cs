using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersService.Domain.Entities;
using UsersService.Domain.Repositories;

namespace UsersService.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public CreateUserCommandHandler(
            ILogger<CreateUserCommandHandler> logger,
            IMapper mapper,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new user");
            var user = _mapper.Map<User>(request);
            Guid guid = await _usersRepository.CreateUser(user);
            return guid;
        }
    }
}
