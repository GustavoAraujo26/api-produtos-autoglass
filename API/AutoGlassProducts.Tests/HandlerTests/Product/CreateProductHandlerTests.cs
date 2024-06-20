using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Tests.FakeData.Product.Request;
using AutoGlassProducts.Tests.FakeData.Product.Response;
using AutoGlassProducts.Tests.FakeData.Supplier.Entity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutoGlassProducts.Tests.HandlerTests.Product
{
    public class CreateProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ISupplierRepository> _SupplierRepositoryMock;
        private readonly CancellationTokenSource _cts;

        public CreateProductHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _SupplierRepositoryMock = new Mock<ISupplierRepository>();
            _cts = new CancellationTokenSource();
        }

        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = CreateProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<ICreateProductHandler>();

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

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var handler = serviceCollection.GetService<ICreateProductHandler>();

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

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = CreateProductRequestFakeData.BuildInvalid();

            var handler = serviceCollection.GetService<ICreateProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenNullSupplier_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(default(Domain.Entities.Supplier));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = CreateProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<ICreateProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }

        [Fact]
        public async Task WhenDisabledSupplier_ReturnFailure()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _SupplierRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(SupplierFakeData.Build(null, Situation.Disabled));

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);
            serviceCollection.AddTransient(x => _SupplierRepositoryMock.Object);

            var request = CreateProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<ICreateProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }
    }
}
