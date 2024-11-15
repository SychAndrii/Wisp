using ExerciseGrpc;
using ExercisesApplication.Contracts;
using Grpc.Core;
using SharedPresentation.Base;
using ApplicationService = ExercisesApplication.Services.ExerciseService;
using GRPCService = ExerciseGrpc.ExerciseService;

namespace ExercisesPresentation.Controllers
{
    public class ExerciseControllerGRPC : GRPCService.ExerciseServiceBase
    {
        private readonly ApplicationService _exerciseService;
        private readonly IPresentationMapper _mapper;

        public ExerciseControllerGRPC(ApplicationService exerciseService, IPresentationMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        public override async Task<StandardExerciseMessage> AddExercise(StandardExerciseMessage request, ServerCallContext context)
        {
            var standardExerciseDto = _mapper.Map<StandardExerciseDTO>(request);
            var exercise = await _exerciseService.AddExercise(standardExerciseDto);
            return _mapper.Map<StandardExerciseMessage>(exercise);
        }

        public override async Task<ExerciseListMessage> GetExercises(EmptyMessage request, ServerCallContext context)
        {
            var exercises = await _exerciseService.GetExercises();
            var result = _mapper.Map<ExerciseListMessage>(exercises);
            return result;
        }
    }
}
