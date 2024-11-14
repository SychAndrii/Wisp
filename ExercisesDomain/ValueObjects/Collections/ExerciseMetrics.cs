using ExercisesDomain.ValueObjects.Enums;
using SharedDomain.Exceptions;
using SharedDomain.ValueObjects;
using System.Collections.Frozen;

namespace ExercisesDomain.ValueObjects.Collections
{
    public record ExerciseMetrics : ValueObject
    {
        public FrozenSet<ExerciseMetric> Metrics { get; }

        private ExerciseMetrics(FrozenSet<ExerciseMetric> metrics)
        {
            Metrics = metrics;
        }

        public static ExerciseMetrics Create(IEnumerable<ExerciseMetric> metrics)
        {
            if (!metrics.Any())
            {
                throw new InvalidFieldException("There has to be at least one metric.");
            }

            return new ExerciseMetrics(metrics.ToFrozenSet());
        }
    }
}
