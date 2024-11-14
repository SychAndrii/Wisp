using ExercisesDomain.ValueObjects;
using ExercisesDomain.ValueObjects.Collections;
using ExercisesDomain.ValueObjects.Enums;
using SharedDomain.Exceptions;
using SharedDomain.ValueObjects;

namespace ExercisesDomain.Builders
{
    public class ExerciseCoreBuilder
    {
        private Guid _id = Guid.NewGuid();
        private ExerciseName _name = ExerciseName.Create(new NormalizedString("Default Name"));
        private ExerciseDifficulty _difficulty = ExerciseDifficulty.MEDIUM;
        private ExerciseDescription? _description;
        private HashSet<Muscle> _primaryMuscles = [];
        private HashSet<Muscle> _secondaryMuscles = [];
        private HashSet<ExerciseMetric> _metrics = [];
        private ExerciseEquipment? _equipment;

        public ExerciseCoreBuilder WithName(string name)
        {
            _name = ExerciseName.Create(new NormalizedString(name));
            return this;
        }

        public ExerciseCoreBuilder WithDifficulty(ExerciseDifficulty difficulty)
        {
            _difficulty = difficulty;
            return this;
        }

        public ExerciseCoreBuilder WithDescription(string description)
        {
            _description = ExerciseDescription.Create(new NormalizedString(description));
            return this;
        }

        public ExerciseCoreBuilder AddPrimaryMuscle(Muscle muscle)
        {
            _primaryMuscles.Add(muscle);
            return this;
        }

        public ExerciseCoreBuilder AddSecondaryMuscle(Muscle muscle)
        {
            if (_primaryMuscles.Contains(muscle))
            {
                throw new InvalidFieldException($"{muscle} is already a primary muscle.");
            }
            _secondaryMuscles.Add(muscle);
            return this;
        }

        public ExerciseCoreBuilder WithEquipment(ExerciseEquipment equipment)
        {
            _equipment = equipment;
            return this;
        }

        public ExerciseCoreBuilder AddMetric(ExerciseMetric metric)
        {
            _metrics.Add(metric);
            return this;
        }

        public ExerciseCoreBuilder FromAnotherCore(ExerciseCore anotherCore)
        {
            _name = anotherCore.Name;
            _difficulty = anotherCore.Difficulty;
            _description = anotherCore.Description;
            _primaryMuscles = anotherCore.Muscles?.PrimaryMuscles.ToHashSet() ?? [];
            _secondaryMuscles = anotherCore.Muscles?.SecondaryMuscles.ToHashSet() ?? [];
            _equipment = anotherCore.Equipment;
            _metrics = anotherCore.Metrics?.Metrics.ToHashSet() ?? [];

            return this;
        }

        public ExerciseCore Build()
        {
            ExerciseMuscles? muscles = null;
            if (_primaryMuscles.Count != 0 || _secondaryMuscles.Count != 0)
            {
                muscles = ExerciseMuscles.Create(_primaryMuscles, _secondaryMuscles);
            }

            ExerciseMetrics? metrics = null;
            if (_metrics.Count != 0)
            {
                metrics = ExerciseMetrics.Create(_metrics);
            }

            return ExerciseCore.Create(
                _id,
                _name,
                _difficulty,
                _description,
                muscles,
                _equipment,
                metrics
            );
        }
    }
}
