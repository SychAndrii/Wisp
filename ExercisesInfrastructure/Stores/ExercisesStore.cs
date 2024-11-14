using ExercisesDomain.Aggregates;
using ExercisesDomain.Stores;

namespace ExercisesInfrastructure.Stores
{
    public class ExercisesStore(ApplicationContext context) : IExercisesStore
    {
        private readonly ApplicationContext context = context;

        public async Task<StandardExercise> AddExercise(StandardExercise exercise)
        {
            await context.StandardExercises.AddAsync(exercise);
            await context.SaveChangesAsync();
            return exercise;
        }
    }
}
