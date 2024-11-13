using ExercisesDomain.ValueObjects;

namespace ExercisesDomain
{
    public class Exercise
    {
        public Guid Id { get; }
        public ExerciseName Name { get; }
        public ExerciseDescription? Description { get; }

        private Exercise(Guid id, ExerciseName name, ExerciseDescription? desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }

        public static Exercise Create(Guid id, ExerciseName name, ExerciseDescription? desc)
        {
            return new Exercise(id, name, desc);
        }
    }
}
