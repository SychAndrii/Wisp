using ExercisesApplication.Contracts;
using ExercisesApplication.Services;
using ExercisesDomain.Aggregates;
using ExercisesDomain.Stores;
using ExercisesDomain.ValueObjects;
using ExercisesInfrastructure;
using ExercisesInfrastructure.Mappers;
using ExercisesInfrastructure.Resolvers.Application;
using ExercisesInfrastructure.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedApplication.Base;

namespace ExercisesComposition
{
    public static class ExercisesServiceExtensions
    {
        public static IServiceCollection AddExercisesServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase("ExercisesService");
            });

            services.AddAutoMapper(config =>
            {
                config.CreateMap<ExerciseCoreDTO, ExerciseCore>()
                    .ConvertUsing<ExerciseCoreResolver>();

                config.CreateMap<StandardExerciseDTO, StandardExercise>()
                    .ConvertUsing<StandardExerciseResolver>();
            });

            services.AddSingleton<IExercisesStore, ExercisesStore>();
            services.AddSingleton<IApplicationMapper, ApplicationAutoMapper>();

            services.AddSingleton<ExerciseService>();

            return services;
        }
    }
}
