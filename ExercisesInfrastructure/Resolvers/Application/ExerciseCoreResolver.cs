using AutoMapper;
using ExercisesApplication.Contracts;
using ExercisesDomain.Builders;
using ExercisesDomain.ValueObjects;
using ExercisesDomain.ValueObjects.Enums;

namespace ExercisesInfrastructure.Resolvers.Application
{
    public class ExerciseCoreResolver : ITypeConverter<ExerciseCoreDTO, ExerciseCore>
    {
        public ExerciseCore Convert(ExerciseCoreDTO source, ExerciseCore destination, ResolutionContext context)
        {
            var builder = new ExerciseCoreBuilder()
                .WithName(source.Name)
                .WithDifficulty(Enum.Parse<ExerciseDifficulty>(source.Difficulty, true));

            if (source.Description is not null)
            {
                builder
                    .WithDescription(source.Description);
            }

            foreach (var muscle in source.PrimaryMuscles)
            {
                builder.AddPrimaryMuscle(Enum.Parse<Muscle>(muscle, true));
            }

            foreach (var muscle in source.SecondaryMuscles)
            {
                builder.AddSecondaryMuscle(Enum.Parse<Muscle>(muscle, true));
            }

            if (source.Equipment is not null)
            {
                builder.WithEquipment(Enum.Parse<ExerciseEquipment>(source.Equipment, true));
            }

            foreach (var metric in source.Metrics)
            {
                builder.AddMetric(Enum.Parse<ExerciseMetric>(metric, true));
            }

            return builder.Build();
        }
    }
}
