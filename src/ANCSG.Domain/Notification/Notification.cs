namespace ANCSG.Domain.Notification
{
    public sealed record Notification
    {
        public string Message { get; init; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
