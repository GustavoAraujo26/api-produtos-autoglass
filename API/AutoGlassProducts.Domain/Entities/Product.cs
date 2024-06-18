using AutoGlassProducts.Domain.Enums;
using System;

namespace AutoGlassProducts.Domain.Entities
{
    /// <summary>
    /// Entidade representante de produtos
    /// </summary>
    public sealed class Product
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Código</param>
        /// <param name="description">Descrição</param>
        /// <param name="status">Status</param>
        /// <param name="madeOn">Data de fabricação</param>
        /// <param name="expiresAt">Data de validade</param>
        /// <param name="supplier">Fornecedor</param>
        public Product(int id, string description, Status status, 
            DateTime madeOn, DateTime expiresAt, Supplier? supplier = null)
        {
            Id = id;
            Description = description;
            Status = status;
            MadeOn = madeOn;
            ExpiresAt = expiresAt;

            if (supplier is not null)
                Supplier = supplier;
        }

        /// <summary>
        /// Código
        /// </summary>
        public int Id { get; private set; }

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

        /// <summary>
        /// Fornecedor
        /// </summary>
        public Supplier Supplier { get; private set; }

        /// <summary>
        /// Cria novo produto
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="madeOn">Data de fabricação</param>
        /// <param name="expiresAt">Data de validade</param>
        /// <returns>Dados do produto</returns>
        public static Product Create(string description, DateTime madeOn, DateTime expiresAt) =>
            new Product(0, description, Status.Enabled, madeOn, expiresAt);

        /// <summary>
        /// Adiciona novo fornecedor
        /// </summary>
        /// <param name="supplier">Dados do fornecedor</param>
        public void AddSupplier(Supplier supplier) => 
            Supplier = supplier;

        /// <summary>
        /// Habilita o produto
        /// </summary>
        public void Enable() => Status = Status.Enabled;

        /// <summary>
        /// Desabilita o produto
        /// </summary>
        public void Disable() => Status = Status.Disabled;
    }
}
