using AutoMapper;
using ExerciseGrpc;
using ExercisesApplication.Contracts;

namespace ExercisesPresentation.Profiles
{
    public class GRPCExerciseProfile : Profile
    {
        public GRPCExerciseProfile()
        {
            // Map from gRPC message to DTO
            CreateMap<StandardExerciseMessage, StandardExerciseDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
                .ForMember(dest => dest.Equipment, opt => opt.MapFrom(src => src.Equipment ?? string.Empty))
                .ForMember(dest => dest.PrimaryMuscles, opt => opt.MapFrom(src => src.PrimaryMuscles.ToList()))
                .ForMember(dest => dest.SecondaryMuscles, opt => opt.MapFrom(src => src.SecondaryMuscles.ToList()))
                .ForMember(dest => dest.Metrics, opt => opt.MapFrom(src => src.Metrics.ToList()))
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.VideoURL, opt => opt.MapFrom(src => src.VideoUrl));

            // Map from DTO to gRPC message
            CreateMap<StandardExerciseDTO, StandardExerciseMessage>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
                .ForMember(dest => dest.Equipment, opt => opt.MapFrom(src => src.Equipment ?? string.Empty))
                .ForMember(dest => dest.PrimaryMuscles, opt => opt.MapFrom(src => src.PrimaryMuscles ?? new List<string>()))
                .ForMember(dest => dest.SecondaryMuscles, opt => opt.MapFrom(src => src.SecondaryMuscles ?? new List<string>()))
                .ForMember(dest => dest.Metrics, opt => opt.MapFrom(src => src.Metrics ?? new List<string>()))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageURL))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoURL));

            // Map from gRPC ExerciseListMessage to List<StandardExerciseDTO>
            CreateMap<ExerciseListMessage, List<StandardExerciseDTO>>()
                .ConvertUsing((src, dest, context) => src.Exercises.Select(e => context.Mapper.Map<StandardExerciseDTO>(e)).ToList());

            // Map from List<StandardExerciseDTO> to gRPC ExerciseListMessage
            CreateMap<List<StandardExerciseDTO>, ExerciseListMessage>()
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom((src, dest, destMember, context) => src.Select(e => context.Mapper.Map<StandardExerciseMessage>(e)).ToList()));
        }
    }
}