using ExercisesDomain.Aggregates;

namespace ExercisesDomain.Stores
{
    public interface IExercisesStore
    {
        public Task<StandardExercise> AddExercise(StandardExercise exercise);
        public Task<IEnumerable<StandardExercise>> GetExercises();
    }
}
