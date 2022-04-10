using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ANCSG.Application.UseCase
{
    public abstract record RequestBase
    {
        protected ValidationResult validationResult;

        public RequestBase()
        {
            validationResult = new ValidationResult();
        }

        [JsonIgnore]
        public abstract bool IsValid { get; }

        [JsonIgnore]
        public ICollection<Domain.Notification.Notification> Notifications
        {
            get => validationResult.Errors.Select(x => new Domain.Notification.Notification(x.ErrorMessage)).ToList();
        }
    }
}
