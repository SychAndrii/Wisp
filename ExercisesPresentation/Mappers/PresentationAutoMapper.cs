using AutoMapper;
using ExercisesPresentation.Profiles;
using SharedPresentation.Base;

namespace ExercisesPresentationLibrary.Mappers
{
    public class PresentationAutoMapper : IPresentationMapper
    {
        private readonly IMapper mapper;

        public PresentationAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GRPCExerciseProfile>();
            });

            mapper = config.CreateMapper();
        }

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
