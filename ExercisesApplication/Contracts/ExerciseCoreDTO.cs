﻿#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace ExercisesApplication.Contracts
{
    public record ExerciseCoreDTO
    {
        public string Name { get; init; }
        public string Difficulty { get; init; }
        public string? Description { get; init; }
        public string? Equipment { get; init; }
        public List<string> PrimaryMuscles { get; init; }
        public List<string> SecondaryMuscles { get; init; }
        public List<string> Metrics { get; init; }
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
