using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Tests.FakeData.Product.Entity;
using AutoGlassProducts.Tests.FakeData.Product.Request;
using AutoGlassProducts.Tests.FakeData.Product.Response;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutoGlassProducts.Tests.HandlerTests.Product
{
    public class GetProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly CancellationTokenSource _cts;

        public GetProductHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _cts = new CancellationTokenSource();
        }

        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            //Arrange
            var serviceCollection = TestEnvironment.BuildEnvironment();

            _productRepositoryMock.Setup(x => x.Save(It.IsAny<Domain.Entities.Product>()))
                .ReturnsAsync(ProductResponseFakeData.Build());

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);

            var request = GetProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IGetProductHandler>();

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
                .ReturnsAsync(ProductFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);

            var handler = serviceCollection.GetService<IGetProductHandler>();

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

            _productRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(ProductFakeData.Build());

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);

            var request = GetProductRequestFakeData.BuildInvalid();

            var handler = serviceCollection.GetService<IGetProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
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

            serviceCollection.AddTransient(x => _productRepositoryMock.Object);

            var request = GetProductRequestFakeData.BuildValid();

            var handler = serviceCollection.GetService<IGetProductHandler>();

            //Act
            var response = await handler.Handle(request, _cts.Token);

            //Assert
            Assert.True(response.IsFailure);
            Assert.Null(response.Content);
        }
    }
}
