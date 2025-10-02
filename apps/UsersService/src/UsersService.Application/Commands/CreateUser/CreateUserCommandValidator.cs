using FluentValidation;

namespace UsersService.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required");
            RuleFor(dto => dto.FirstName)
                .NotEmpty().WithMessage("First name is required");
            RuleFor(dto => dto.LastName)
                .NotEmpty().WithMessage("Last name is required");
            RuleFor(dto => dto.Gender)
                .NotEmpty().WithMessage("Gender is required");
            RuleFor(dto => dto.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required");
            RuleFor(dto => dto.Nationality)
                .NotEmpty().WithMessage("Nationality is required");
        }
    }
}
