using ExercisesDomain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace ExercisesInfrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

        public DbSet<StandardExercise> StandardExercises { get; set; }
    }
}
