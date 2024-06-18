using AutoGlassProducts.Domain.Enums;

namespace AutoGlassProducts.Domain.Entities
{
    /// <summary>
    /// Entidade representante de fornecedores
    /// </summary>
    public sealed class Supplier
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Código</param>
        /// <param name="document">Documento identificador (CNPJ)</param>
        /// <param name="description">Descrição</param>
        /// <param name="status">Status</param>
        public Supplier(int id, string document, string description, Status status)
        {
            Id = id;
            Document = document;
            Description = description;
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
        /// Status
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Cria novo fornecedor
        /// </summary>
        /// <param name="document">Documento identificador (CNPJ)</param>
        /// <param name="desciption">Descrição</param>
        /// <returns>Dados do fornecedor</returns>
        public static Supplier Create(string document, string desciption) =>
            new Supplier(0, document, desciption, Status.Enabled);

        /// <summary>
        /// Habilita fornecedor
        /// </summary>
        public void Enable() => Status = Status.Enabled;

        /// <summary>
        /// Desabilita fornecedor
        /// </summary>
        public void Disable() => Status = Status.Disabled;
    }
}
