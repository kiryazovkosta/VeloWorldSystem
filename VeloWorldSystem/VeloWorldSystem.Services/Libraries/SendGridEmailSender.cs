namespace VeloWorldSystem.Services.Libraries
{
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using VeloWorldSystem.DtoModels.Email;
    using VeloWorldSystem.Services.Libraries.Contracts;
    using static VeloWorldSystem.Common.Constants.GlobalErrorMessages;

    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridClient client;

        public SendGridEmailSender(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException(
                    string.Format(SendGridErrors.ExceptionMessage, nameof(SendGridClient)));
            }

            this.client = new SendGridClient(apiKey);
        }

        public async Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachmentModel> attachments = null)
        {
            if (string.IsNullOrWhiteSpace(subject)
                || string.IsNullOrWhiteSpace(htmlContent))
            {
                throw new ArgumentException(SendGridErrors.EmptyMessage);
            }

            var fromAddress = new EmailAddress(from, fromName);
            var toAddress = new EmailAddress(to);
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, null, htmlContent);
            if (attachments?.Any() == true)
            {
                foreach (var attachment in attachments)
                {
                    message.AddAttachment(
                        attachment.FileName, 
                        Convert.ToBase64String(attachment.Content), 
                        attachment.MimeType);
                }
            }

            await this.client.SendEmailAsync(message);
        }
    }
}
