using AutoMapper;
using SharedPresentation.Base;

namespace ExercisesPresentation.Mappers
{
    public class PresentationAutoMapper : IPresentationMapper
    {
        private readonly IMapper mapper;

        public PresentationAutoMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
