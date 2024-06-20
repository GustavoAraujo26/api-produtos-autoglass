using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoGlassProducts.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de fornecedores
    /// </summary>
    public interface ISupplierRepository
    {
        /// <summary>
        /// Persiste os dados do fornecedor
        /// </summary>
        /// <param name="supplier">Entidade fornecedor</param>
        /// <returns>DTO de resposta de fornecedor</returns>
        Task<SupplierResponse> Save(Supplier supplier);

        /// <summary>
        /// Busca dados do fornecedor pelo seu código
        /// </summary>
        /// <param name="id">Código</param>
        /// <returns>Entidade fornecedor</returns>
        Task<Supplier?> Get(int id);

        /// <summary>
        /// Obtém lista paginada de fornecedores, com base nos dados de pesquisa
        /// </summary>
        /// <param name="listRequest">Requisição de listagem de fornecedores</param>
        /// <returns>DTO de resposta de lista paginada</returns>
        Task<ListSupplierResponse> List(ListSupplierRequest listRequest);

        /// <summary>
        /// Obtém lista de modelos com base em uma lista de Id's
        /// </summary>
        /// <param name="ids">Lista de identificadores para buscar</param>
        /// <returns>Lista de modelos</returns>
        Task<List<SupplierModel>> ListByIds(List<int> ids);
    }
}
