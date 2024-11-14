using ExercisesDomain.ValueObjects.Collections;
using ExercisesDomain.ValueObjects.Enums;
using SharedDomain.Base;

namespace ExercisesDomain.ValueObjects
{
    public record ExerciseCore : ValueObject
    {
        public ExerciseName Name { get; }
        public ExerciseDifficulty Difficulty { get; }
        public ExerciseDescription? Description { get; }
        public ExerciseMuscles? Muscles { get; }
        public ExerciseEquipment? Equipment { get; }
        public ExerciseMetrics? Metrics { get; }

        private ExerciseCore(ExerciseName name,
                           ExerciseDifficulty difficulty,
                           ExerciseDescription? desc,
                           ExerciseMuscles? muscles,
                           ExerciseEquipment? equipment,
                           ExerciseMetrics? metrics)
        {
            Name = name;
            Difficulty = difficulty;
            Description = desc;
            Muscles = muscles;
            Equipment = equipment;
            Metrics = metrics;
        }

        public static ExerciseCore Create(ExerciseName name,
                                      ExerciseDifficulty difficulty,
                                      ExerciseDescription? desc,
                                      ExerciseMuscles? muscles,
                                      ExerciseEquipment? equipment,
                                      ExerciseMetrics? metrics)
        {
            return new ExerciseCore(name, difficulty, desc, muscles, equipment, metrics);
        }
    }
}
