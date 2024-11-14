using ExercisesDomain.ValueObjects;
using ExercisesDomain.ValueObjects.Collections;
using ExercisesDomain.ValueObjects.Enums;

namespace ExercisesDomain.Aggregates
{
    public class Exercise
    {
        public Guid Id { get; }
        public ExerciseName Name { get; set; }
        public ExerciseDescription? Description { get; set; }
        public ExerciseMuscles? Muscles { get; set; }
        public ExerciseEquipment? Equipment { get; set; }
        public ExerciseMetrics? Metrics { get; set; }

        private Exercise(Guid id,
                           ExerciseName name,
                           ExerciseDescription? desc,
                           ExerciseMuscles? muscles,
                           ExerciseEquipment? equipment,
                           ExerciseMetrics? metrics)
        {
            Id = id;
            Name = name;
            Description = desc;
            Muscles = muscles;
            Equipment = equipment;
            Metrics = metrics;
        }

        public static Exercise Create(Guid id,
                                      ExerciseName name,
                                      ExerciseDescription? desc,
                                      ExerciseMuscles? muscles,
                                      ExerciseEquipment? equipment,
                                      ExerciseMetrics? metrics)
        {
            return new Exercise(id, name, desc, muscles, equipment, metrics);
        }
    }
}
