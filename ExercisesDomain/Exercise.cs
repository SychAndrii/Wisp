using SharedDomain.Exceptions;
using SharedDomain.ValueObjects;

namespace ExercisesDomain
{
    public class Exercise
    {
        public Guid Id { get; }
        public NormalizedString Name { get; }

        private const int MAX_NAME_LENGTH = 150;

        private Exercise(Guid id, NormalizedString name)
        {
            Id = id;
            Name = name;
        }

        public Exercise Create(Guid id, NormalizedString name)
        {
            if (name.IsNullOrEmpty())
            {
                throw new InvalidFieldException($"{nameof(name)} cannot be empty.");
            }
            if (name.Length > MAX_NAME_LENGTH)
            {
                throw new InvalidFieldException($"{nameof(name)} cannot be longer than {MAX_NAME_LENGTH} characters.");
            }
            if (!name.MatchesRegex(@"^[A-Za-z\s]+$"))
            {
                throw new InvalidFieldException($"{nameof(name)} cannot contain characters other than uppercase or lowercase letters and spaces.");
            }

            return new Exercise(id, name);
        }
    }
}
