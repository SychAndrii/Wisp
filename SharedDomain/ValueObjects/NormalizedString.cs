using SharedDomain.Base;
using System.Text.RegularExpressions;

namespace SharedDomain.ValueObjects
{
    public record NormalizedString : ValueObject
    {
        public string Value { get; init; }

        public NormalizedString(string value)
        {
            Value = Normalize(value);
        }

        private static string Normalize(string input)
        {
            // Trim the input and replace multiple spaces between words with a single space
            return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public bool IsNullOrWhiteSpace() => string.IsNullOrWhiteSpace(Value);

        public int Length => Value.Length;

        public bool MatchesRegex(string pattern)
        {
            return Regex.IsMatch(Value, pattern);
        }

        public override string ToString() => Value;
    }
}
