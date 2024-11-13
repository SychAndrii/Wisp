using ExercisesDomain.ValueObjects;

namespace ExercisesDomain
{
    public class CustomExercise : Exercise
    {
        public ExerciseLLMCheck LLMCheck { get; set; }
        public ExerciseReviewStatus ReviewStatus { get; set; }

        private CustomExercise(Guid id,
                               ExerciseName name,
                               ExerciseDescription? desc,
                               DateTime createdAt,
                               ExerciseLLMCheck llmCheck,
                               ExerciseReviewStatus reviewStatus) : base(
                                    id,
                                    name,
                                    desc,
                                    createdAt)
        {
            LLMCheck = llmCheck;
            ReviewStatus = reviewStatus;
        }

        public static CustomExercise Create(Guid id,
                                            ExerciseName name,
                                            ExerciseDescription? desc,
                                            DateTime createdAt,
                                            ExerciseLLMCheck llmCheck,
                                            ExerciseReviewStatus reviewStatus = ExerciseReviewStatus.PENDING)
        {
            return new CustomExercise(id, name, desc, createdAt, llmCheck, reviewStatus);
        }
    }
}
