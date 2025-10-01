namespace UsersService.Domain.ValueObjects
{
    public sealed class PasswordHash
    {
        public string Value { get; } = null!;

        private PasswordHash() {}

        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be null or whitespace!", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object? obj)
        {
            if (obj is PasswordHash passwordHash)
                return Value == passwordHash.Value;

            return false;
        }
    }
}
