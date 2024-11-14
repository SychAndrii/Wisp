using ExercisesDomain.ValueObjects.Collections;
using ExercisesDomain.ValueObjects.Enums;

namespace ExercisesDomain.ValueObjects
{
    public class ExerciseCore
    {
        public ExerciseName Name { get; set; }
        public ExerciseDifficulty Difficulty { get; set; }
        public ExerciseDescription? Description { get; set; }
        public ExerciseMuscles? Muscles { get; set; }
        public ExerciseEquipment? Equipment { get; set; }
        public ExerciseMetrics? Metrics { get; set; }

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
