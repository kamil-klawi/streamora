namespace UsersService.Domain.ValueObjects
{
    public sealed class UserRole
    {
        public string Value { get; } = null!;

        public static readonly UserRole Admin = new("ADMIN");
        public static readonly UserRole Editor = new("EDITOR");
        public static readonly UserRole User = new("USER");

        private static readonly HashSet<string> _allowedRoles = new(StringComparer.OrdinalIgnoreCase)
        {
            Admin.Value,
            Editor.Value,
            User.Value
        };

        private UserRole() {}

        public UserRole(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
               throw new ArgumentException("Role cannot be null or whitespace!", nameof(value));

            if (!_allowedRoles.Contains(value))
                throw new ArgumentException("Role is not a valid value!", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        public override int GetHashCode() => Value.ToUpperInvariant().GetHashCode();

        public override bool Equals(object? obj) => Equals(obj as UserRole);

        private bool Equals(UserRole? role)
        {
            return role is not null && string.Equals(Value, role.Value, StringComparison.OrdinalIgnoreCase);
        }

        public static implicit operator string(UserRole userRole) => userRole.Value;
    }
}
