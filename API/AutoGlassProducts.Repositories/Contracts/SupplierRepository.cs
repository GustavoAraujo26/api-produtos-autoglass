using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Repositories;
using System;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using AutoMapper;
using AutoGlassProducts.Domain.Models;
using AutoGlassProducts.Repositories.Sql;
using System.Collections.Generic;
using ArchitectureTools.Pagination;
using System.Text;
using AutoGlassProducts.Domain.DTO.Supplier;
using System.Linq;

namespace AutoGlassProducts.Repositories.Contracts
{
    internal class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public SupplierRepository(IMapper mapper)
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            _mapper = mapper;
        }

        public async Task<Supplier> Get(int id)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                var model = await db.QueryFirstOrDefaultAsync<SupplierModel>(SupplierSql.GetById, new { Id = id });
                if (model == null)
                    return null;

                return _mapper.Map<Supplier>(model);
            }
        }

        public async Task<ListSupplierResponse> List(ListSupplierRequest listRequest)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                int totalItems = await db.QueryFirstOrDefaultAsync<int>(SupplierSql.GetTotalRows);

                List<string> queryItems = new List<string>();

                if (!string.IsNullOrEmpty(listRequest.DescriptionTrack))
                    queryItems.Add($"[description] like '%{listRequest.DescriptionTrack}%'");

                if (!string.IsNullOrEmpty(listRequest.DocumentTrack))
                    queryItems.Add($"[supplier_document] like '%{listRequest.DocumentTrack}%'");

                if (listRequest.Situation.HasValue)
                    queryItems.Add($"[situation] = {(int)listRequest.Situation}");

                StringBuilder sb = new StringBuilder();
                sb.Append(SupplierSql.List);

                if (queryItems.Count != 0)
                    sb.Append($" WHERE {string.Join(" AND ", queryItems)}");

                var page = Page.Create(listRequest.Page, listRequest.PageSize, totalItems);
                sb.Append($" ORDER BY [id] ASC OFFSET {page.Skip} ROWS FETCH NEXT {page.Size} ROWS ONLY");

                string sql = sb.ToString();

                var modelList = await db.QueryAsync<SupplierModel>(sql);

                var dtoList = _mapper.Map<List<SupplierDTO>>(modelList.ToList());

                return new ListSupplierResponse(dtoList, page);
            }
        }

        public async Task<List<SupplierModel>> ListByIds(List<int> ids)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                var modelList = await db.QueryAsync<SupplierModel>(SupplierSql.ListByIds, new { IdList = ids });

                return modelList.ToList();
            }
        }

        public async Task<SupplierResponse> Save(Supplier supplier)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (var db = new SqlConnection(_connectionString))
            {
                string sql = SupplierSql.Insert;
                if (supplier.Id != 0)
                    sql = SupplierSql.Update;

                var model = _mapper.Map<SupplierModel>(supplier);

                var id = await db.ExecuteScalarAsync<int>(sql, model);

                return new SupplierResponse(supplier.Id.Equals(0) ? id : supplier.Id, supplier.Description);
            }
        }
    }
}
