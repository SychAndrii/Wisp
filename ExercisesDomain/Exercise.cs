using ExercisesDomain.ValueObjects;

namespace ExercisesDomain
{
    public class Exercise
    {
        public Guid Id { get; }
        public ExerciseName Name { get; set; }
        public ExerciseDescription? Description { get; set; }
        public ExerciseMuscles? Muscles { get; set; }

        protected Exercise(Guid id, ExerciseName name, ExerciseDescription? desc, ExerciseMuscles? muscles)
        {
            Id = id;
            Name = name;
            Description = desc;
            Muscles = muscles;
        }

        public static Exercise Create(Guid id,
                                      ExerciseName name,
                                      ExerciseDescription? desc,
                                      ExerciseMuscles? muscles)
        {
            return new Exercise(id, name, desc, muscles);
        }
    }
}
