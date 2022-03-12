using ANCSG.Domain.Email;
using System.Threading.Tasks;

namespace ANCSG.Application.EmailNotification
{
    public interface IEmailSender
    {
        Task SendAsync(Email email);
    }
}
