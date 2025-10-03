using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersService.Application.Exceptions;
using UsersService.Domain.Repositories;

namespace UsersService.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public DeleteUserCommandHandler(
            ILogger<DeleteUserCommandHandler> logger,
            IMapper mapper,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting user {@request}", request);
            var user = await _usersRepository.GetUserById(request.Id);
            if (user is null)
                throw new NotFoundException($"User with ID {request.Id} not found");
            await _usersRepository.DeleteUser(user);
        }
    }
}
