using Microsoft.EntityFrameworkCore;
using Moq;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection;
using TestTemplate.Data.Repositories;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.Data;
using VeloWorldSystem.Data.Contracts;
using VeloWorldSystem.DtoModels;
using VeloWorldSystem.DtoModels.BikeTypes;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Models;
using VeloWorldSystem.Services.Services;
using VeloWorldSystem.Services.Tests.Infrastructure;
using Xunit;

namespace VeloWorldSystem.Services.Tests.ApplicationServices
{
    public class BikeTypesServiceTests : QueryTestBase
    {
        [Fact]
        public void BikeTypesServiceCtor_BikeTypeRepositoryIsNull_ThrowsArgumentNullException()
        {
            //Arrange & Act
            Action act = () => new BikeTypeService(null);

            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'bikeTypes')", exception.Message);
        }

        [Theory]
        [InlineData(7, false)]
        [InlineData(3, true)]
        public async Task Exists_ValidUniqueIdentifier_ReturnsCorrect(int id, bool expected)
        {
            //Arrange
            var bikeTypesProvider = new Mock<IDeletableRepository<BikeType>>();
            bikeTypesProvider.Setup(btp => btp.AllAsNoTracking()).Returns(this.Context.BikeTypes);
            var service = new BikeTypeService(bikeTypesProvider.Object);

            // Act
            var result = await service.ExistsAsync(id);

            // Assert
            Assert.Equal<bool>(expected, result);
        }

        [Theory]
        [InlineData(3, "TT Bike")]
        public async Task GetByIdAsync_ExistsId_ReturnsCorrectViewModel(int id, string expected)
        {
            //Arrange

            var bikeTypesProvider = new Mock<IDeletableRepository<BikeType>>();
            bikeTypesProvider.Setup(btp => btp.All()).Returns(this.Context.BikeTypes);
            var service = new BikeTypeService(bikeTypesProvider.Object);

            // Act
            var result = await service.GetByIdAsync<BikeTypeViewModel>(id);

            // Assert
            Assert.Equal(expected, result?.Name);
        }

        [Theory]
        [InlineData(0, "Entity \"BikeType\" 0 was not found!")]
        public async Task GetByIdAsync_NonExistsId_ThrowsNotFoundException(int id, string expected)
        {
            //Arrange

            var bikeTypesProvider = new Mock<IDeletableRepository<BikeType>>();
            bikeTypesProvider.Setup(btp => btp.All()).Returns(this.Context.BikeTypes);
            var service = new BikeTypeService(bikeTypesProvider.Object);

            // Act
            Func<Task> act = () => service.GetByIdAsync<BikeTypeViewModel>(id);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public async Task AddAsync_ValidData_ReturnsIdOfNewAddedRecord()
        {
            //Arrange
            var bikeTypesProvider = new DeletableRepository<BikeType>(this.Context);
            var service = new BikeTypeService(bikeTypesProvider);
            var model = new BikeTypeInputModel { Name= "New bike type" };
            var expectedId = 6;
            var expectedRecordsCountAfter = 6;
            var expectedRecordsCountBefore = 5;
            var recordsCountBefore = this.Context.BikeTypes.Count();

            // Act
            var result = await service.AddAsync(model);

            // Assert
            Assert.Equal<int>(expectedRecordsCountBefore, recordsCountBefore);
            Assert.Equal<int>(expectedId, result);
            Assert.Equal<int>(expectedRecordsCountAfter, this.Context.BikeTypes.Count());
        }

        [Fact]
        public async Task GetAllAsync_ValidData_ReturnsIdOfNewAddedRecord()
        {
            //Arrange
            var bikeTypesProvider = new DeletableRepository<BikeType>(this.Context);
            var service = new BikeTypeService(bikeTypesProvider);
            var expectedRecordsCount = 5;

            // Act
            var result = (await service.GetAllAsync()).OrderBy(bt => bt.Id).ToArray();

            // Assert
            Assert.Equal<int>(expectedRecordsCount, result.Count());
            Assert.Equal<int>(1, result.First().Id);
            Assert.Equal<int>(5, result.Last().Id);
            Assert.Equal("Road Bike", result.First().Name);
            Assert.Equal("Gravel Bike", result.Last().Name);
        }

        [Theory]
        [InlineData(1, "New Name")]
        [InlineData(6, null)]
        public async Task UpdateAsync_ValidData_UpdateRecordDataIfExists(int id, string expected)
        {
            //Arrange
            var model = new BikeTypeInputModel() { Name = "New Name" };
            var bikeTypesProvider = new DeletableRepository<BikeType>(this.Context);
            var service = new BikeTypeService(bikeTypesProvider);

            // Act
            await service.UpdateAsync(id, model);

            // Assert
            Assert.Equal(expected, this.Context.BikeTypes.FirstOrDefault(bt => bt.Id == id)?.Name);
        }

        [Fact]
        public async Task DeleteAsync_ValidData_MakeSoftDeleting()
        {
            //Arrange
            var recordId = 3;
            var bikeTypesProvider = new DeletableRepository<BikeType>(this.Context);
            var service = new BikeTypeService(bikeTypesProvider);
            var beforeDelete = this.Context?.BikeTypes?.Find(recordId)?.IsDeleted;

            // Act
            await service.DeleteAsync(recordId);

            // Assert
            Assert.Equal(false, beforeDelete);
            Assert.Equal(true, this.Context?.BikeTypes?.Find(recordId)?.IsDeleted);
        }

        [Fact]
        public async Task UndeleteAsync_ValidData_RemoveSoftDeleting()
        {
            //Arrange
            var recordId = 6;
            var bikeTypesProvider = new DeletableRepository<BikeType>(this.Context);
            var service = new BikeTypeService(bikeTypesProvider);
            this.Context.BikeTypes.Add(new BikeType { Id = recordId, Name = "Test Name", IsDeleted = true });
            this.Context.SaveChanges();

            // Act
            await service.UndeleteAsync(recordId);

            // Assert
            Assert.Equal(false, this.Context?.BikeTypes?.Find(recordId)?.IsDeleted);
        }


    }
}
