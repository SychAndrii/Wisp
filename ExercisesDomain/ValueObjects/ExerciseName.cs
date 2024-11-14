using SharedDomain.Base;
using SharedDomain.Exceptions;
using SharedDomain.ValueObjects;

namespace ExercisesDomain.ValueObjects
{
    public record ExerciseName : ValueObject
    {
        public NormalizedString Value { get; }

        private const int MAX_NAME_LENGTH = 120;
        private const int MIN_NAME_LENGTH = 5;

        private ExerciseName(NormalizedString name)
        {
            Value = name;
        }

        public static ExerciseName Create(NormalizedString name)
        {
            ValidateName(name);
            return new ExerciseName(name);
        }

        private static void ValidateName(NormalizedString name)
        {
            if (name.IsNullOrWhiteSpace())
            {
                throw new InvalidFieldException($"{nameof(name)} cannot be empty.");
            }
            if (name.Length > MAX_NAME_LENGTH)
            {
                throw new InvalidFieldException($"{nameof(name)} cannot be longer than {MAX_NAME_LENGTH} characters.");
            }
            if (name.Length < MIN_NAME_LENGTH)
            {
                throw new InvalidFieldException($"{nameof(name)} cannot be shorter than {MIN_NAME_LENGTH} characters.");
            }
            if (!name.MatchesRegex(@"^[A-Za-z\s]+$"))
            {
                throw new InvalidFieldException($"{nameof(name)} cannot contain characters other than uppercase or lowercase letters and spaces.");
            }
        }
    }
}
