using TestTemplate.Data.Repositories;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.DtoModels.Bikes;
using VeloWorldSystem.Models.Entities.Models;
using VeloWorldSystem.Services.Services;
using VeloWorldSystem.Services.Tests.Infrastructure;

namespace VeloWorldSystem.Services.Tests.ApplicationServices
{
    public class BikesServiceTests : QueryTestBase
    {
        [Fact]
        public void BikesServiceCtor_NullIDeletableRepositoryBile_ThrowsArgumentNullException()
        {
            //Arrange & Act
            Action act = () => new BikesService(null);

            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'bikesRepo')", exception.Message);
        }

        [Fact]
        public async Task CreateAsync_ValidInputModel_CreateRecord()
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);
            var bikesCountBefore = this.Context.Bikes.Count();
            var model = new BikeInputModel() { BikeTypeId = 2, Name = "New Bike", Brand = "Orbea", Model = "OIZ 30", Weight = 9.80, UserId = "a45b8508-7efc-4623-9798-747a484f8820" };

            // Act
            await service.CreateAsync(model);

            // Assert
            Assert.True(bikesCountBefore == 5);
            Assert.True(this.Context.Bikes.Count() == 6);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_MakeSoftDeleting()
        {
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            await service.DeleteAsync(1);

            Assert.True(this.Context?.Bikes?.Find(1)?.IsDeleted == true);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(6, false)]
        public async Task ExistsAsync_ValidInput_ReturnsTrueOrFalsedependingOnExisting(int id, bool expected)
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            var result = await service.ExistsAsync(id);

            // Assert
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData("a45b8508-7efc-4623-9798-747a484f8820", 3)]
        [InlineData("00000000-0000-0000-0000-000000000000", 0)]
        public async Task GetAllAsync_UserIdentifier_ReturnsCollectionsWithUserBikes(string userId, int expected)
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            var result = await service.GetAllAsync<BikeListViewModel>(userId);

            // Assert
            Assert.True(result.Count() == expected);
            if (result.Count() > 0)
            {
                Assert.Equal(result.OrderBy(b => b.Id).Select(b => b.Id).ToArray(), new int[] { 1, 3, 4 });
            }
        }

        [Theory]
        [InlineData(2, "Scott Spark")]
        public async Task GetByIdAsync_ExistsId_ReturnsValidBikeView(int id, string expected)
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            var result = await service.GetByIdAsync<BikeListViewModel>(id);

            // Assert
            Assert.True(result?.Name == expected);
        }

        [Theory]
        [InlineData(6, "Entity \"Bike\" 6 was not found!")]
        public async Task GetByIdAsync_NonExistsId_ThrowArgumentException(int id, string expected)
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            Func<Task> act = () => service.GetByIdAsync<BikeListViewModel>(id);

            //Assert
            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Theory]
        [InlineData(0, "3816a499-e914-41cf-826a-f5cf586080be", false)]
        [InlineData(1, "3816a499-e914-41cf-826a-f5cf586080be", false)]
        [InlineData(5, "3816a499-e914-41cf-826a-f5cf586080be", true)]
        public async Task IsOwner_BikeIdAndUserId_RetursIsUserWithUserIdIsOnerOfBike(int id, string userId, bool expected)
        {
            // Arrange
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            var result = await service.IsOwner(id, userId);

            // Assert
            Assert.True(result == expected);
        }

        [Fact]
        public async Task UpdateAsync_NonExistsRecord_ThrowNotFoundException()
        {
            // Arrange
            var id = 0;
            var userId = "3816a499-e914-41cf-826a-f5cf586080be";
            var model = new BikeInputModel { BikeTypeId = 2, Brand = "NewBrand", Model = "NewModel", Name = "NewName", Notes = "NewNotes", Weight = 10.00, UserId = userId };
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            Func<Task> act = () => service.UpdateAsync(id, model);

            //Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("Entity \"Bike\" 0 was not found!", exception.Message);
        }

        [Fact]
        public async Task UpdateAsync_NotAOwner_ThrowNotAuthorizedException()
        {
            // Arrange
            var id = 1;
            var userId = "3816a499-e914-41cf-826a-f5cf586080be";
            var model = new BikeInputModel { BikeTypeId = 2, Brand = "NewBrand", Model = "NewModel", Name = "NewName", Notes = "NewNotes", Weight = 10.00, UserId = userId };
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            Func<Task> act = () => service.UpdateAsync(id, model);

            //Assert
            var exception = await Assert.ThrowsAsync<NotAuthenticatedException>(act);
            Assert.Equal("Does not have permissions for Entity \"Bike\" 1!", exception.Message);
        }

        [Fact]
        public async Task UpdateAsync_ValidInput_UpdateRecord()
        {
            // Arrange
            var id = 5;
            var userId = "3816a499-e914-41cf-826a-f5cf586080be";
            var model = new BikeInputModel { BikeTypeId = 2, Brand = "NewBrand", Model = "NewModel", Name = "NewName", Notes = "NewNotes", Weight = 10.00, UserId = userId };
            var bikesProvider = new DeletableRepository<Bike>(this.Context);
            var service = new BikesService(bikesProvider);

            // Act
            await service.UpdateAsync(id, model);
            var bike = this.Context.Bikes.Find(id);

            //Assert
            Assert.Equal(id, bike?.Id);
            Assert.Equal(2, bike?.BikeTypeId);
            Assert.Equal("NewBrand", bike?.Brand);
            Assert.Equal("NewModel", bike?.Model);
            Assert.Equal("NewName", bike?.Name);
            Assert.Equal("NewNotes", bike?.Notes);
            Assert.Equal(10.00, bike?.Weight);
        }
    }
}
