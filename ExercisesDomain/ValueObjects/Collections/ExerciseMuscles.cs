using ExercisesDomain.ValueObjects.Enums;
using SharedDomain.Exceptions;
using System.Collections.Frozen;

namespace ExercisesDomain.ValueObjects.Collections
{
    public class ExerciseMuscles
    {
        public FrozenSet<Muscle> PrimaryMuscles { get; }
        public FrozenSet<Muscle> SecondaryMuscles { get; }

        private ExerciseMuscles(FrozenSet<Muscle> primaryMuscles, FrozenSet<Muscle> secondaryMuscles)
        {
            PrimaryMuscles = primaryMuscles;
            SecondaryMuscles = secondaryMuscles;
        }

        public static ExerciseMuscles Create(IEnumerable<Muscle> primaryMuscles, IEnumerable<Muscle> secondaryMuscles)
        {
            if (!primaryMuscles.Any())
            {
                throw new InvalidFieldException("There has to be at least one primary muscle.");
            }

            if (primaryMuscles.Intersect(secondaryMuscles).Any())
            {
                throw new InvalidFieldException($"Primary and secondary muscles have to contain different values.");
            }

            return new ExerciseMuscles(primaryMuscles.ToFrozenSet(), secondaryMuscles.ToFrozenSet());
        }
    }
}
