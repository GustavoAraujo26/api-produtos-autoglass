using AutoGlassProducts.Domain.Enums;
using System;

namespace AutoGlassProducts.Domain.Models
{
    /// <summary>
    /// Modelo representante do produto
    /// </summary>
    public sealed class ProductModel
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Código</param>
        /// <param name="supplierId">Código do fornecedor</param>
        /// <param name="description">Descrição</param>
        /// <param name="status">Status</param>
        /// <param name="madeOn">Data de fabricação</param>
        /// <param name="expiresAt">Data de validade</param>
        public ProductModel(int id, int supplierId, string description, 
            Status status, DateTime madeOn, DateTime expiresAt)
        {
            Id = id;
            SupplierId = supplierId;
            Description = description;
            Status = status;
            MadeOn = madeOn;
            ExpiresAt = expiresAt;
        }

        /// <summary>
        /// Código
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Código do fornecedor
        /// </summary>
        public int SupplierId { get; private set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Data de fabricação
        /// </summary>
        public DateTime MadeOn { get; private set; }

        /// <summary>
        /// Data de validade
        /// </summary>
        public DateTime ExpiresAt { get; private set; }
    }
}
