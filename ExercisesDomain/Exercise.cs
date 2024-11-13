using ExercisesDomain.ValueObjects;

namespace ExercisesDomain
{
    public class Exercise
    {
        public Guid Id { get; }
        public ExerciseName Name { get; }
        public ExerciseDescription? Description { get; }
        public DateTime CreatedAt { get; }

        private Exercise(Guid id, ExerciseName name, ExerciseDescription? desc, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = desc;
            CreatedAt = createdAt;
        }

        public static Exercise Create(Guid id,
                                      ExerciseName name,
                                      ExerciseDescription? desc,
                                      DateTime createdAt)
        {
            return new Exercise(id, name, desc, createdAt);
        }
    }
}
