using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TestTemplate.Data.Repositories;
using VeloWorldSystem.Common.Constants;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.DtoModels.Bikes;
using VeloWorldSystem.Models.Entities.Identity;
using VeloWorldSystem.Services.Libraries;
using VeloWorldSystem.Services.Libraries.Contracts;
using VeloWorldSystem.Services.Services;
using static VeloWorldSystem.Common.Constants.GlobalErrorMessages;

namespace VeloWorldSystem.Services.Tests.ApplicationServices.Libraries
{
    public class CloudinaryServiceTests
    {
        [Fact]
        public void CloudinaryServiceCtor_NullCloudinary_ThrowsArgumentNullException()
        {
            //Arrange & Act
            Action act = () => new CloudinaryService(null);

            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'Cloudinary')", exception.Message);
        }

        [Fact]
        public void IsFileValid_PhotoFileIsNull_ReturnsFalse()
        {
            // Arrange
            var expected = false;
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            var result = service.IsFileValid(null);

            // Assert
            Assert.True(result == expected);
        }

        [Fact]
        public void IsFileValid_PhotoFileHasInvalidContentType_ReturnsFalse()
        {
            // Arrange
            var expected = false;
            var file = new Mock<IFormFile>();
            file.Setup(p => p.ContentType).Returns("text/plain");   
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            var result = service.IsFileValid(file.Object);

            // Assert
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData("text/plain", false)]
        [InlineData("video/x-flv", false)]
        [InlineData("image/x-png", true)]
        [InlineData("image/gif", true)]
        [InlineData("image/jpeg", true)]
        [InlineData("image/jpg", true)]
        [InlineData("image/png", true)]
        public void IsFileValid_PhotoFile_ReturnsTrueOrFileDeppendingOnInputFileContentType(string contentType, bool expected)
        {
            // Arrange
            var file = new Mock<IFormFile>();
            file.Setup(p => p.ContentType).Returns(contentType);
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            var result = service.IsFileValid(file.Object);

            // Assert
            Assert.True(result == expected);
        }

        [Fact]
        public async Task UploudArrayAsync_ArgumentIsNull_ThrowsCloudinaryUploadException()
        {
            // Arrange
            var expected = CloudinaryErrors.ExceptionMessage;
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            Func<Task> act = () => service.UploudArrayAsync(null);

            //Assert
            CloudinaryUploadException exception = await Assert.ThrowsAsync<CloudinaryUploadException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public async Task UploudArrayAsync_ArgumentIsEmpty_ThrowsCloudinaryUploadException()
        {
            // Arrange
            var emptyArray = new byte[] { };
            var expected = CloudinaryErrors.ExceptionMessage;
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            Func<Task> act = () => service.UploudArrayAsync(emptyArray);

            //Assert
            CloudinaryUploadException exception = await Assert.ThrowsAsync<CloudinaryUploadException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public async Task UploudAsync_ArgumentIsNull_ThrowsCloudinaryUploadException()
        {
            // Arrange
            var expected = CloudinaryErrors.ExceptionMessage;
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            Func<Task> act = () => service.UploudAsync(null);

            //Assert
            CloudinaryUploadException exception = await Assert.ThrowsAsync<CloudinaryUploadException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public async Task UploudAsync_ArgumentIsEmpty_ThrowsCloudinaryUploadException()
        {
            // Arrange
            var file = new Mock<IFormFile>();
            file.Setup(f => f.ContentType).Returns("application/json");
            var expected = CloudinaryErrors.ExceptionMessage;
            var cloudinaryCredentials = new Account("test");
            var cloudinary = new Mock<Cloudinary>(cloudinaryCredentials);
            var service = new CloudinaryService(cloudinary.Object);

            // Act
            Func<Task> act = () => service.UploudAsync(file.Object);

            //Assert
            CloudinaryUploadException exception = await Assert.ThrowsAsync<CloudinaryUploadException>(act);
            Assert.Equal(expected, exception.Message);
        }
    }
}
