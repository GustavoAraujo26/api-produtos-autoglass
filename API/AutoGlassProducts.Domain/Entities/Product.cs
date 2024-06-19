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
        /// <param name="description">Descrição</param>
        /// <param name="situation">Situação</param>
        /// <param name="madeOn">Data de fabricação</param>
        /// <param name="expiresAt">Data de validade</param>
        /// <param name="id">Código</param>
        /// <param name="supplier">Fornecedor</param>
        public Product(string description, Situation situation, 
            DateTime madeOn, DateTime expiresAt, int id = 0, Supplier? supplier = null)
        {
            Id = id;
            Description = description;
            Situation = situation;
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
        /// Situação
        /// </summary>
        public Situation Situation { get; private set; }

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
            new Product(description, Situation.Enabled, madeOn, expiresAt);

        /// <summary>
        /// Realiza cópia dos dados do produto
        /// </summary>
        /// <param name="product">Dados do produto a ser copiado</param>
        /// <returns>Dados do novo produto</returns>
        public static Product Copy(Product product) => 
            new Product(product.Description, product.Situation, product.MadeOn, 
                product.ExpiresAt, product.Id, Supplier.Copy(product.Supplier));

        /// <summary>
        /// Adiciona novo fornecedor
        /// </summary>
        /// <param name="supplier">Dados do fornecedor</param>
        public void AddSupplier(Supplier supplier) => 
            Supplier = supplier;

        /// <summary>
        /// Habilita o produto
        /// </summary>
        public void Enable() => Situation = Situation.Enabled;

        /// <summary>
        /// Desabilita o produto
        /// </summary>
        public void Disable() => Situation = Situation.Disabled;

        /// <summary>
        /// Atualiza dados básicos
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="madeOn">Data de fabricação</param>
        /// <param name="expiresAt">Data de validade</param>
        public void UpdateBasicData(string description, DateTime madeOn, DateTime expiresAt)
        {
            Description = description;
            MadeOn = madeOn;
            ExpiresAt = expiresAt;
        }
    }
}
