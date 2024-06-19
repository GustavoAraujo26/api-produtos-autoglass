using AutoGlassProducts.Domain.Enums;

namespace AutoGlassProducts.Domain.Models
{
    /// <summary>
    /// Modelo representante do fornecedor
    /// </summary>
    public sealed class SupplierModel
    {
        /// <summary>
        /// Construtor para inicializar as propriedade
        /// </summary>
        /// <param name="id">Código</param>
        /// <param name="document">Documento identificador (CNPJ)</param>
        /// <param name="description">Descrição</param>
        /// <param name="situation">Situação</param>
        public SupplierModel(int id, string document, string description, Situation situation)
        {
            Id = id;
            Document = document;
            Description = description;
            Situation = situation;
        }

        /// <summary>
        /// Código
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Documento identificador (CNPJ)
        /// </summary>
        public string Document { get; private set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Situação
        /// </summary>
        public Situation Situation { get; private set; }
    }
}
