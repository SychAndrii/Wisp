using ExercisesApplication.Contracts.Exercise;
using ExercisesDomain.Aggregates;
using ExercisesDomain.Stores;
using SharedApplication.Base;

namespace ExercisesApplication.Services
{
    public class ExerciseService(IExercisesStore store, IMapper mapper)
    {
        private readonly IExercisesStore store = store;
        private readonly IMapper mapper = mapper;

        public async Task<StandardExercise> AddExercise(AddStandardExerciseDTO dto)
        {
            StandardExercise exercise = mapper.Map<StandardExercise>(dto);
            StandardExercise result = await store.AddExercise(exercise);
            return result;
        }
    }
}
