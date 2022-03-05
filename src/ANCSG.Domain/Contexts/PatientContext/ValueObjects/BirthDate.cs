using System;

namespace ANCSG.Domain.Contexts.PatientContext.ValueObjects
{
    public class BirthDate
    {
        public DateTime Date { get; private set; }

        public BirthDate(DateTime date)
        {
            Date = date;
        }
    }
}
