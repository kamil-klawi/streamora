using UsersService.Domain.ValueObjects;

namespace UsersService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; } = null!;
        public PasswordHash Password { get; private set; } = null!;
        public PersonalData PersonalData { get; private set; } = null!;
        public UserRole Role { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private User() {}

        public User(Guid id, Email email, PasswordHash password, PersonalData personalData, UserRole role)
        {
            Id = id;
            Email = email;
            Password = password;
            PersonalData = personalData;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
