namespace ANCSG.Domain.DomainEntities.ValueObjects
{
    public struct Phone
    {
        public int Code { get; private set; }

        public string Number { get; private set; }

        public Phone(int code, string number) : this()
        {
            Code = code;
            Number = number;
        }
    }
}
