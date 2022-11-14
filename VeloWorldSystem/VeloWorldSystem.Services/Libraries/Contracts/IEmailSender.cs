using VeloWorldSystem.DtoModels.Email;

namespace VeloWorldSystem.Services.Libraries.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachmentModel> attachments = null);
    }
}
