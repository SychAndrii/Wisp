using SharedDomain.Base;
using SharedDomain.Exceptions;

namespace SharedDomain.ValueObjects
{
    public record HttpLink : ValueObject
    {
        public NormalizedString Value { get; }

        private HttpLink(NormalizedString link)
        {
            Value = link;
        }

        public static HttpLink Create(NormalizedString link)
        {
            if (link.IsNullOrWhiteSpace())
            {
                throw new InvalidFieldException("Link cannot be empty!");
            }

            if (!link.MatchesRegex(@"^(https?:\/\/)[a-zA-Z0-9\-_]+(\.[a-zA-Z0-9\-_]+)+(:\d+)?(\/.*)?$"))
            {
                throw new InvalidFieldException("The link does not follow http(s) format!");
            }

            return new HttpLink(link);
        }
    }
}
