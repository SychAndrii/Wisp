using ExercisesDomain.Aggregates;

namespace ExercisesDomain.Stores
{
    public interface IExercisesStore
    {
        Task<StandardExercise> AddExercise(StandardExercise exercise);
    }
}
