using ExercisesApplication.Contracts;
using ExercisesDomain.Aggregates;
using ExercisesDomain.Stores;
using SharedApplication.Base;

namespace ExercisesApplication.Services
{
    public class ExerciseService(IExercisesStore store, IApplicationMapper mapper)
    {
        private readonly IExercisesStore store = store;
        private readonly IApplicationMapper mapper = mapper;

        public async Task<StandardExercise> AddExercise(StandardExerciseDTO dto)
        {
            StandardExercise exercise = mapper.Map<StandardExercise>(dto);
            StandardExercise result = await store.AddExercise(exercise);
            return result;
        }

        public async Task<IEnumerable<StandardExercise>> GetExercises()
        {
            IEnumerable<StandardExercise> result = await store.GetExercises();
            return result;
        }
    }
}
