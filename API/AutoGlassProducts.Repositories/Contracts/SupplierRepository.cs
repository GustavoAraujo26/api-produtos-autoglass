using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace AutoGlassProducts.Repositories.Contracts
{
    internal class SupplierRepository : ISupplierRepository
    {
        public Task<Supplier> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ListSupplierResponse> List(ListSupplierRequest listRequest)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierResponse> Save(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
