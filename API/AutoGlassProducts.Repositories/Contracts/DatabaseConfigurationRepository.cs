using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.Repositories;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using AutoGlassProducts.Repositories.Sql;

namespace AutoGlassProducts.Repositories.Contracts
{
    internal class DatabaseConfigurationRepository : IDatabaseConfigurationRepository
    {
        public async Task<ActionResponse<object>> CheckConfiguration()
        {
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
                if (string.IsNullOrEmpty(connectionString))
                    return ActionResponse<object>.InternalError("Connection string not found!");

                using (var db = new SqlConnection(connectionString))
                {
                    int? databaseId = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfDatabaseExists);
                    if (!databaseId.HasValue)
                        return ActionResponse<object>.NotFound("Database not found!");

                    int? supplierTableExists = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfSupplierTableExists);
                    if (!supplierTableExists.HasValue || (supplierTableExists.HasValue && supplierTableExists.Value == 0))
                        return ActionResponse<object>.NotFound("Supplier table not found!");

                    int? productTableExists = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfProductTableExists);
                    if (!productTableExists.HasValue || (productTableExists.HasValue && productTableExists.Value == 0))
                        return ActionResponse<object>.NotFound("Product table not found!");
                }

                return ActionResponse<object>.Ok();
            }
            catch(Exception ex)
            {
                return ActionResponse<object>.InternalError(ex);
            }
        }

        public async Task<ActionResponse<object>> Configure()
        {
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
                if (string.IsNullOrEmpty(connectionString))
                    return ActionResponse<object>.InternalError("Connection string not found!");

                using (var db = new SqlConnection(connectionString))
                {
                    //Verifica se o banco de dados existe
                    int? databaseId = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfDatabaseExists);
                    if (!databaseId.HasValue)
                    {
                        //Criando banco de dados
                        await db.ExecuteAsync(DatabaseConfigurationSql.CreateDatabase);
                    }

                    //Verifica se a tabela de fornecedores existe
                    int? supplierTableExists = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfSupplierTableExists);
                    if (!supplierTableExists.HasValue || (supplierTableExists.HasValue && supplierTableExists.Value == 0))
                    {
                        //Criando tabela de fornecedor
                        await db.ExecuteAsync(DatabaseConfigurationSql.CreateSupplierTable);
                    }

                    //Verifica se a tabela de produtos existe
                    int? productTableExists = await db.QueryFirstOrDefaultAsync<int?>(DatabaseConfigurationSql.CheckIfProductTableExists);
                    if (!productTableExists.HasValue || (productTableExists.HasValue && productTableExists.Value == 0))
                    {
                        //Criando tabela de produtos
                        await db.ExecuteAsync(DatabaseConfigurationSql.CreateProductTable);

                        //Criando chave estrangeira de fornecedores com produtos
                        await db.ExecuteAsync(DatabaseConfigurationSql.CreateForeignKeySupplierOnProductTable);
                    }
                }
                
                return ActionResponse<object>.Ok();
            }
            catch(Exception ex)
            {
                return ActionResponse<object>.InternalError(ex);
            }
        }
    }
}
