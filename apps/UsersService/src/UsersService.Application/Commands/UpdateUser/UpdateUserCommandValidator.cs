using FluentValidation;

namespace UsersService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required");
            RuleFor(dto => dto.FirstName)
                .NotEmpty().WithMessage("First name is required");
            RuleFor(dto => dto.LastName)
                .NotEmpty().WithMessage("Last name is required");
        }
    }
}
