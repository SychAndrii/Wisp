using SharedDomain.Base;
using SharedDomain.Exceptions;
using SharedDomain.ValueObjects;

namespace ExercisesDomain.ValueObjects
{
    public record ExerciseDescription : ValueObject
    {
        public NormalizedString Value { get; }

        private const int MAX_DESCRIPTION_LENGTH = 500;
        private const int MIN_DESCRIPTION_LENGTH = 40;

        private ExerciseDescription(NormalizedString description)
        {
            Value = description;
        }

        public static ExerciseDescription? Create(NormalizedString? description)
        {
            if (description == null)
            {
                return null; // It's fine if the description is null.
            }

            ValidateDescription(description);
            return new ExerciseDescription(description);
        }

        private static void ValidateDescription(NormalizedString description)
        {
            if (description.IsNullOrWhiteSpace())
            {
                throw new InvalidFieldException($"{nameof(description)} cannot be empty.");
            }
            if (description.Length > MAX_DESCRIPTION_LENGTH)
            {
                throw new InvalidFieldException($"{nameof(description)} cannot be longer than {MAX_DESCRIPTION_LENGTH} characters.");
            }
            if (description.Length < MIN_DESCRIPTION_LENGTH)
            {
                throw new InvalidFieldException($"{nameof(description)} cannot be shorter than {MIN_DESCRIPTION_LENGTH} characters.");
            }
        }
    }
}
