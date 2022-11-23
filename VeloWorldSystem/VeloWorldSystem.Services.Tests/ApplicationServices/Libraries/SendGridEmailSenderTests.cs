using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.DtoModels.Email;
using VeloWorldSystem.Services.Libraries;
using static VeloWorldSystem.Common.Constants.GlobalErrorMessages;

namespace VeloWorldSystem.Services.Tests.ApplicationServices.Libraries
{
    public class SendGridEmailSenderTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void SendGridEmailSenderCtr_InvalidApiKey_ThrowsArgumentException(string key)
        {
            //Arrange & Act
            Action act = () => new SendGridEmailSender(key);

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'SendGridClient')", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task SendEmailAsync_InvalidSubject_ThrowsArgumentException(string subject)
        {
            //Arrange
            var service = new SendGridEmailSender("test");

            // Act
            Func<Task> act = () => service.SendEmailAsync("from", "fromName", "to", subject, "content");

            //Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(act);
            Assert.Equal(SendGridErrors.EmptyMessage, exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task SendEmailAsync_InvalidContent_ThrowsArgumentException(string content)
        {
            //Arrange
            var service = new SendGridEmailSender("test");

            // Act
            Func<Task> act = () => service.SendEmailAsync("from", "fromName", "to", "subject", content);

            //Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(act);
            Assert.Equal(SendGridErrors.EmptyMessage, exception.Message);
        }

        [Fact]
        public async Task SendEmailAsync_Valid_SendEmail()
        {
            //Arrange
            var service = new SendGridEmailSender("test");

            // Act
            await service.SendEmailAsync("from", "fromName", "to", "subject", "content");
        }

        [Fact]
        public async Task SendEmailAsync_ValidWithAttachments_SendEmail()
        {
            //Arrange
            var service = new SendGridEmailSender("test");

            // Act
            await service.SendEmailAsync(
                "from", 
                "fromName", 
                "to", 
                "subject", 
                "content", 
                new List<EmailAttachmentModel>() 
                { 
                    new EmailAttachmentModel 
                    { 
                        Content = new byte[] { 1, 50, 200 }, 
                        FileName = "fileName", 
                        MimeType = "mimeType"
                    } 
                });
        }
    }
}
