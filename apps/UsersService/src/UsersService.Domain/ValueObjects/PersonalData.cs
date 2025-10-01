namespace UsersService.Domain.ValueObjects
{
    public sealed class PersonalData
    {
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;
        public string Gender { get; } = null!;
        public DateOnly DateOfBirth { get; }
        public string Nationality { get; } = null!;

        private PersonalData() {}

        public PersonalData(string firstName, string lastName, string gender, DateOnly dateOfBirth, string nationality)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName cannot be null or whitespace.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName cannot be null or whitespace.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender cannot be null or whitespace.", nameof(gender));

            if (dateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));

            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("Nationality cannot be null or whitespace.", nameof(nationality));

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Nationality = nationality;
        }
    }
}
