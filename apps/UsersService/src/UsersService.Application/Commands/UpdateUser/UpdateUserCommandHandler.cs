using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersService.Application.Exceptions;
using UsersService.Domain.Repositories;

namespace UsersService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UpdateUserCommandHandler(
            ILogger<UpdateUserCommandHandler> logger,
            IMapper mapper,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating user details");
            var user = await _usersRepository.GetUserById(request.Id);
            if (user is null)
                throw new NotFoundException($"User with ID {request.Id} not found");

            user.UpdatePersonalData(request.FirstName, request.LastName);

            if (!string.IsNullOrWhiteSpace(request.Password))
                user.UpdatePassword(request.Password);

            await _usersRepository.UpdateUser(user);
        }
    }
}
