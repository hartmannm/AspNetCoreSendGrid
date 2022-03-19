using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ANCSG.Application.UseCase
{
    public abstract record RequestBase
    {
        protected ValidationResult validationResult;

        public RequestBase()
        {
            validationResult = new ValidationResult();
        }

        public abstract bool IsValid { get; }

        public ICollection<Domain.Notification.Notification> Notifications
        {
            get => validationResult.Errors.Select(x => new Domain.Notification.Notification(x.ErrorMessage)).ToList();
        }
    }
}
