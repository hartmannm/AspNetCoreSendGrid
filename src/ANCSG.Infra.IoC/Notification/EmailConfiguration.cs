using ANCSG.Application.EmailNotification;
using ANCSG.Domain.Email;
using ANCSG.Infra.Notification.Email.SendGrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.Notification
{
    internal static class EmailConfiguration
    {
        public static IServiceCollection ConfigureEmail(this IServiceCollection services, IConfiguration configuration)
        {
            var sendGridKey = configuration.GetSection("Notification:Email:ApiKey").Value;

            services.AddSendGrid(options => options.ApiKey = sendGridKey);

            var emailOptions = new Domain.Email.EmailConfiguration();
            configuration.GetSection("Notification:Email:Config").Bind(emailOptions);

            services.AddSingleton(emailOptions);
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
