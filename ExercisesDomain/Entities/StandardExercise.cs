using ExercisesDomain.ValueObjects;
using SharedDomain.Base;
using SharedDomain.ValueObjects;

namespace ExercisesDomain.Aggregates
{
    public class StandardExercise : Entity
    {
        public ExerciseCore Core { get; set; }
        public HttpLink ImageURL { get; set; }
        public HttpLink VideoURL { get; set; }

        private StandardExercise(ExerciseCore core, HttpLink imageURL, HttpLink videoURL)
        {
            Core = core;
            ImageURL = imageURL;
            VideoURL = videoURL;
        }

        public static StandardExercise Create(ExerciseCore core, HttpLink img, HttpLink video)
        {
            return new StandardExercise(core, img, video);
        }
    }
}
