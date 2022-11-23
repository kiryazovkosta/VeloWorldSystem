using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTemplate.Data.Repositories;
using VeloWorldSystem.Common.Constants;
using VeloWorldSystem.Data.Contracts;
using VeloWorldSystem.DtoModels.Account;
using VeloWorldSystem.Models.Entities.Identity;
using VeloWorldSystem.Models.Entities.Models;
using VeloWorldSystem.Services.Libraries.Contracts;
using VeloWorldSystem.Services.Services;
using VeloWorldSystem.Services.Tests.Infrastructure;
using Xunit;

namespace VeloWorldSystem.Services.Tests.ApplicationServices
{
    public class UsersServiceTests : QueryTestBase
    {
        [Fact]
        public  void UsersServiceCtor_ApplicationUserIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var cloudinaryStub = new Mock<ICloudinaryService>();

            //Act
            Action act = () => new UsersService(null, cloudinaryStub.Object);

            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'ApplicationUser')", exception.Message);
        }

        [Fact]
        public void UsersServiceCtor_ICloudinaryServiceIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var usersMock = new Mock<IDeletableRepository<ApplicationUser>>();

            //Act
            Action act = () => new UsersService(usersMock.Object, null);

            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'CloudinaryService')", exception.Message);
        }

        [Fact]
        public async Task CreateUser_AvatarInInputModelIsNull_ReturnsUserWithDefaultImageUrl()
        {
            // Arrange
            var cloudinary = new Mock<ICloudinaryService>();
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);
            var model = new RegisterInputModel() { Avatar = null };

            // Act
            var result = await service.CreateUser(model);

            // Assert
            Assert.True(result.ImageUrl == GlobalConstants.Images.DefaultAvatarImage);
        }

        [Fact]
        public async Task CreateUser_AvatarFileIsInInvalidFormat_ReturnsUserWithDefaultImageUrl()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var cloudinary = new Mock<ICloudinaryService>();
            cloudinary.Setup(c => c.IsFileValid(It.IsAny<IFormFile>())).Returns(false);
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);
            var model = new RegisterInputModel() { Avatar = fileMock.Object };

            // Act
            var result = await service.CreateUser(model);

            // Assert
            Assert.True(result.ImageUrl == GlobalConstants.Images.DefaultAvatarImage);
        }

        [Fact]
        public async Task CreateUser_AUploadToCloudinaryThrowsException_ReturnsUserWithDefaultImageUrl()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var cloudinary = new Mock<ICloudinaryService>();
            cloudinary.Setup(c => c.IsFileValid(It.IsAny<IFormFile>())).Returns(true);
            cloudinary.Setup(c => c.UploudAsync(It.IsAny<IFormFile>())).Throws<Exception>();
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);
            var model = new RegisterInputModel() { Avatar = fileMock.Object };

            // Act
            var result = await service.CreateUser(model);

            // Assert
            Assert.True(result.ImageUrl == GlobalConstants.Images.DefaultAvatarImage);
        }

        [Fact]
        public async Task CreateUser_AUploadToCloudinaryThrowsException_ReturnsUploadedImageUrl()
        {
            // Arrange
            var uploadedFileUrl = "url_path_to_the_uploaded_file";
            var fileMock = new Mock<IFormFile>();
            var cloudinary = new Mock<ICloudinaryService>();
            cloudinary.Setup(c => c.IsFileValid(It.IsAny<IFormFile>())).Returns(true);
            cloudinary.Setup(c => c.UploudAsync(It.IsAny<IFormFile>())).Returns(Task.FromResult(uploadedFileUrl));
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);
            var model = new RegisterInputModel() { Avatar = fileMock.Object };

            // Act
            var result = await service.CreateUser(model);

            // Assert
            Assert.True(result.ImageUrl == uploadedFileUrl);
        }

        [Theory]
        [InlineData("a45b8508-7efc-4623-9798-747a484f8820", true)]
        [InlineData("00000000-0000-0000-0000-000000000000", false)]
        public async Task IsUserExistsAsync_ValidInput_ReturnsBooleanDependingOnUserId(string userId, bool expected)
        {
            // Arrange
            var cloudinary = new Mock<ICloudinaryService>();
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);

            // Act
            var result = await service.IsUserExistsAsync(userId);

            // Assert
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData("user", true)]
        [InlineData("empty", false)]
        public async Task IsFileValid_ValidInput_ReturnsBooleanDependingOnUserId(string userName, bool expected)
        {
            // Arrange
            var cloudinary = new Mock<ICloudinaryService>();
            var users = new DeletableRepository<ApplicationUser>(this.Context);
            var service = new UsersService(users, cloudinary.Object);

            // Act
            var result = await service.IsUsernameExistsAsync(userName);

            // Assert
            Assert.True(result == expected);
        }
    }
}
