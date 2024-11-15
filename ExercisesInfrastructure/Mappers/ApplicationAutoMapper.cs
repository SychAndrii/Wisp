using AutoMapper;
using ExercisesApplication.Contracts;
using ExercisesDomain.Aggregates;
using ExercisesDomain.ValueObjects;
using ExercisesInfrastructure.Resolvers.Application;
using SharedApplication.Base;

namespace ExercisesInfrastructure.Mappers
{
    public class ApplicationAutoMapper : IApplicationMapper
    {
        private readonly IMapper mapper;

        public ApplicationAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExerciseCoreDTO, ExerciseCore>().ConvertUsing<ExerciseCoreResolver>();
                cfg.CreateMap<StandardExerciseDTO, StandardExercise>().ConvertUsing<StandardExerciseResolver>();
            });

            mapper = config.CreateMapper();
        }

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
