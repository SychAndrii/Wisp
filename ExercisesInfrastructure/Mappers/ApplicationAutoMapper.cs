using AutoMapper;
using SharedApplication.Base;

namespace ExercisesInfrastructure.Mappers
{
    public class ApplicationAutoMapper : IApplicationMapper
    {
        private readonly IMapper mapper;

        public ApplicationAutoMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
