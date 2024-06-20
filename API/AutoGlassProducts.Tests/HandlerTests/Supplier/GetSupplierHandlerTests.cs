﻿using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Tests.FakeData.Supplier.Entity;
using AutoGlassProducts.Tests.FakeData.Supplier.Request;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutoGlassProducts.Tests.HandlerTests.Supplier
{
    public class GetSupplierHandlerTests
    {
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;
        private readonly CancellationTokenSource _cts;

        public GetSupplierHandlerTests()
        {
            _supplierRepositoryMock = new Mock<ISupplierRepository>();
            _cts = new CancellationTokenSource();
        }

        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _supplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _supplierRepositoryMock.Object);

            var request = GetSupplierRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IGetSupplierHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task WhenNullRequest_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _supplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _supplierRepositoryMock.Object);

            var handler = serviceCollection.GetService<IGetSupplierHandler>();

            //Act
            var response = await handler.Handle(null, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenInvalidRequest_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _supplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _supplierRepositoryMock.Object);

            var request = GetSupplierRequestFakeData.BuildInvalid();

            var handler = serviceCollection.GetService<IGetSupplierHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenSupplierNotFound_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _supplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(default(Domain.Entities.Supplier));

            serviceCollection.AddTransient(x => _supplierRepositoryMock.Object);

            var request = GetSupplierRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IGetSupplierHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }
    }
}
