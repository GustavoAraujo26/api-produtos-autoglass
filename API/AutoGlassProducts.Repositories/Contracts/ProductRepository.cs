using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Repositories.Sql;
using AutoMapper;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using ArchitectureTools.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoGlassProducts.Domain.DTO.Product;

namespace AutoGlassProducts.Repositories.Contracts
{
    internal class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public ProductRepository(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<Product> Get(int id)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                var model = await db.QueryFirstOrDefaultAsync<ProductModel>(ProductSql.GetById, new { Id = id });
                if (model == null)
                    return null;

                var supplier = await _supplierRepository.Get(model.SupplierId);

                var entity = _mapper.Map<Product>(model);
                entity.AddSupplier(supplier);

                return entity;
            }
        }

        public async Task<ListProductResponse> List(ListProductsRequest request)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                int totalItems = await db.QueryFirstOrDefaultAsync<int>(ProductSql.GetTotalRows);

                var page = Page.Create(request.Page, request.PageSize, totalItems);

                string sql = BuildSql(request, page);

                var modelList = await db.QueryAsync<ProductModel>(sql);

                var dtoList = await BuildListToConvert(modelList.ToList());

                return new ListProductResponse(dtoList, page);
            }
        }

        public async Task<ProductResponse> Save(Product product)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                string sql = ProductSql.Insert;
                if (product.Id != 0)
                    sql = ProductSql.Update;

                var model = _mapper.Map<ProductModel>(product);

                var id = await db.ExecuteScalarAsync<int>(sql, model);

                return new ProductResponse(product.Id.Equals(0) ? id : product.Id, product.Description);
            }
        }

        private string BuildSql(ListProductsRequest request, Page page)
        {
            List<string> queryItems = new List<string>();

            if (!string.IsNullOrEmpty(request.DescriptionTrack))
                queryItems.Add($"p.[description] like '%{request.DescriptionTrack}%'");

            if (request.ProductSituation.HasValue)
                queryItems.Add($"p.[situation] = {(int)request.ProductSituation}");

            if (request.MadePeriod.HasValue)
                queryItems.Add($"p.[made_on] BETWEEN " +
                    $"'{request.MadePeriod.Value.Start.ToString("yyyy-MM-dd HH:mm:ss:fff")}' AND " +
                    $"'{request.MadePeriod.Value.End.ToString("yyyy-MM-dd HH:mm:ss:fff")}'");

            if (request.ExpirationPeriod.HasValue)
                queryItems.Add($"p.[expires_at] BETWEEN " +
                    $"'{request.ExpirationPeriod.Value.Start.ToString("yyyy-MM-dd HH:mm:ss:fff")}' AND " +
                    $"'{request.ExpirationPeriod.Value.End.ToString("yyyy-MM-dd HH:mm:ss:fff")}'");

            if (!string.IsNullOrEmpty(request.SupplierDescriptionTrack))
                queryItems.Add($"s.[description] like '%{request.SupplierDescriptionTrack}%'");

            if (!string.IsNullOrEmpty(request.SupplierDocumentTrack))
                queryItems.Add($"s.[supplier_document] like '%{request.SupplierDocumentTrack}%'");

            if (request.SupplierSituation.HasValue)
                queryItems.Add($"s.[situation] = {(int)request.SupplierSituation}");

            StringBuilder sb = new StringBuilder();
            sb.Append(ProductSql.List);

            if (queryItems.Count != 0)
                sb.Append($" WHERE {string.Join(" AND ", queryItems)}");

            sb.Append($" ORDER BY [id] ASC OFFSET {page.Skip} ROWS FETCH NEXT {page.Size} ROWS ONLY");

            return sb.ToString();
        }

        private async Task<List<ProductDTO>> BuildListToConvert(List<ProductModel> productModels)
        {
            var supplierIdList = productModels.Select(x => x.SupplierId).Distinct().ToList();

            var supplierModels = await _supplierRepository.ListByIds(supplierIdList);

            List<Tuple<ProductModel, SupplierModel>> containerList = new List<Tuple<ProductModel, SupplierModel>>();

            foreach(var product in productModels)
            {
                var currentSupplier = supplierModels.FirstOrDefault(x => x.Id == product.SupplierId);
                containerList.Add(new Tuple<ProductModel, SupplierModel>(product, currentSupplier));
            }

            return _mapper.Map<List<ProductDTO>>(containerList);
        }
    }
}
