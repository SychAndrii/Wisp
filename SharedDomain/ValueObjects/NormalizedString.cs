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

        public bool IsNullOrWhiteSpace() => string.IsNullOrWhiteSpace(Value);

        public int Length => Value.Length;

        public bool MatchesRegex(string pattern)
        {
            return Regex.IsMatch(Value, pattern);
        }

        public bool IsHttpLink()
        {
            const string httpPattern = @"^http:\/\/[a-zA-Z0-9\-_]+(\.[a-zA-Z0-9\-_]+)+(:\d+)?(\/.*)?$";
            return MatchesRegex(httpPattern);
        }

        public bool IsHttpsLink()
        {
            const string httpsPattern = @"^https:\/\/[a-zA-Z0-9\-_]+(\.[a-zA-Z0-9\-_]+)+(:\d+)?(\/.*)?$";
            return MatchesRegex(httpsPattern);
        }

        public bool OnlyContainsLettersAndSpaces()
        {
            return MatchesRegex(@"^[A-Za-z\s]+$");
        }

        public override string ToString() => Value;
    }
}
