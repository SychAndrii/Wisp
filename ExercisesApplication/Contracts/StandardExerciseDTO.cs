﻿#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace ExercisesApplication.Contracts
{
    public record StandardExerciseDTO : ExerciseCoreDTO
    {
        public string ImageURL { get; init; }
        public string VideoURL { get; init; }
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.