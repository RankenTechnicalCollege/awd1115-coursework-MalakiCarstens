using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FandomFinds
{
    public class NullEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // No-op for development. Replace with real implementation for production.
            return Task.CompletedTask;
        }
    }
}



