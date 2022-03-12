namespace ANCSG.Domain.Notification
{
    public sealed class Notification
    {
        public string Message { get; private set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
