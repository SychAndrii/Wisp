using AutoMapper;
using ExercisesApplication.Contracts;
using ExercisesDomain.Aggregates;
using ExercisesDomain.ValueObjects;
using SharedDomain.ValueObjects;

namespace ExercisesInfrastructure.Resolvers.Application
{
    public class StandardExerciseResolver : ITypeConverter<StandardExerciseDTO, StandardExercise>
    {
        public StandardExercise Convert(StandardExerciseDTO source, StandardExercise destination, ResolutionContext context)
        {
            // Assuming ExerciseCore is derived from ExerciseCoreDTO
            var core = context.Mapper.Map<ExerciseCore>(source);

            // Convert the URLs to HttpLink objects
            var imageUrl = HttpLink.Create(new NormalizedString(source.ImageURL));
            var videoUrl = HttpLink.Create(new NormalizedString(source.VideoURL));

            // Create and return the StandardExercise using its factory method
            return StandardExercise.Create(core, imageUrl, videoUrl);
        }
    }
}
