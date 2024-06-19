using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Tests.FakeData.Product.Entity;
using AutoGlassProducts.Tests.FakeData.Product.Request;
using AutoGlassProducts.Tests.FakeData.Product.Response;
using AutoGlassProducts.Tests.FakeData.Supplier.Entity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutoGlassProducts.Tests.HandlerTests.Product
{
    public class EditProductHandlerFakeData
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ISupplierRepository> _SupplierRepositoryMock;
        private readonly CancellationTokenSource _cts;

        public EditProductHandlerFakeData()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _SupplierRepositoryMock = new Mock<ISupplierRepository>();
            _cts = new CancellationTokenSource();
        }

        [Fact]
        public async Task WhenValidRequest_WithSameSupplier_ReturnSuccess()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(1));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildValid(1);

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task WhenValidRequest_WithDifferentSupplier_ReturnSuccess()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(2));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildValid(2);

            var handler = serviceCollection.GetService<IEditProductHandler>();

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

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(1));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(null, _cts.Token);

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenInvalidRequest_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(1));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildInvalid();

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenProductNotFound_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(default(Domain.Entities.Product));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(1));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenSupplierNotFound_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(default(Domain.Entities.Supplier));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenChangeToDisabledSupplier_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build(1));

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(2, Situation.Disabled));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = EditProductRequestFakeData.BuildValid(2);

            var handler = serviceCollection.GetService<IEditProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Content);
        }
    }
}
