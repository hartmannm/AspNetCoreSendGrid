using System.Threading.Tasks;

namespace ANCSG.Domain.Email
{
    public interface IEmailSender
    {
        Task SendAsync(Email email);
    }
}
