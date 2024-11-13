using SharedDomain.Exceptions;

namespace ExercisesDomain.ValueObjects
{
    public class ExerciseMuscles(List<Muscle> primaryMuscles, List<Muscle> secondaryMuscles)
    {
        private List<Muscle> PrimaryMuscles { get; } = primaryMuscles;
        private List<Muscle> SecondaryMuscles { get; } = secondaryMuscles;

        public IReadOnlyList<Muscle> Primary => PrimaryMuscles;
        public IReadOnlyList<Muscle> Secondary => SecondaryMuscles;

        public static ExerciseMuscles Create(List<Muscle> primaryMuscles, List<Muscle> secondaryMuscles)
        {
            if (primaryMuscles.Count == 0)
            {
                throw new InvalidFieldException($"There has to be at least one primary muscle.");
            }
            return new ExerciseMuscles(primaryMuscles, secondaryMuscles);
        }
    }
}
