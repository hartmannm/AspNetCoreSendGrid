namespace ANCSG.Domain.Notification
{
    public struct Notification
    {
        public string Message { get; private set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
