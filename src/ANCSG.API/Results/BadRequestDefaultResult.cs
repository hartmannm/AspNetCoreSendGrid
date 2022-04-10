namespace ANCSG.API.Results
{
    public sealed class BadRequestDefaultResult
    {
        public IReadOnlyList<string> Errors { get; }

        public BadRequestDefaultResult(IEnumerable<string> errors)
        {
            Errors = errors.ToList().AsReadOnly();
        }
    }
}
