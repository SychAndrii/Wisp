using System.Text.RegularExpressions;

namespace SharedDomain.ValueObjects
{
    public record NormalizedString
    {
        public string Value { get; }

        public NormalizedString(string value)
        {
            Value = Normalize(value);
        }

        private static string Normalize(string input)
        {
            // Trim the input and replace multiple spaces between words with a single space
            return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public bool IsNullOrEmpty() => string.IsNullOrEmpty(Value);

        public int Length => Value.Length;

        public bool MatchesRegex(string pattern)
        {
            return Regex.IsMatch(Value, pattern);
        }

        public override string ToString() => Value;
    }
}
