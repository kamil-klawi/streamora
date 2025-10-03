using System.Text.RegularExpressions;

namespace UsersService.Domain.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; } = null!;

        private Email() {}

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or whitespace!", nameof(value));

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email is not a valid e-mail address!", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object? obj)
        {
            if (obj is Email email)
                return Value == email.Value;

            return false;
        }

        public static implicit operator string(Email email) => email.Value;
    }
}
