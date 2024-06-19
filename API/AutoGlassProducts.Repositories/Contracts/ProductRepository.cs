using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace AutoGlassProducts.Repositories.Contracts
{
    internal class ProductRepository : IProductRepository
    {
        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ListProductResponse> List(ListProductsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
