namespace ExercisesApplication.Contracts.Exercise
{
    public record AddStandardExerciseDTO
    {
        public string Name { get; init; }
        public string Difficulty { get; init; }
        public string? Description { get; init; }
        public List<string> PrimaryMuscles { get; init; }
        public List<string> SecondaryMuscles { get; init; }
        public List<string> Equipment { get; init; }
        public List<string> Metrics { get; init; }
        public string ImageURL { get; init; }
        public string VideoURL { get; init; }
    }
}
