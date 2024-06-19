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
        /// <param name="document">Documento identificador (CNPJ)</param>
        /// <param name="description">Descrição</param>
        /// <param name="situation">Situação</param>
        /// <param name="id">Código</param>
        public Supplier(string document, string description, Situation situation, int id = 0)
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
        /// Situação
        /// </summary>
        public Situation Situation { get; private set; }

        /// <summary>
        /// Cria novo fornecedor
        /// </summary>
        /// <param name="document">Documento identificador (CNPJ)</param>
        /// <param name="desciption">Descrição</param>
        /// <returns>Dados do fornecedor</returns>
        public static Supplier Create(string document, string desciption) =>
            new Supplier(document, desciption, Situation.Enabled, 0);

        /// <summary>
        /// Realiza cópia dos dados do fornecedor
        /// </summary>
        /// <param name="supplier">Fornecedor a ser copiado</param>
        /// <returns>Dados do novo fornecedor</returns>
        public static Supplier Copy(Supplier supplier) =>
            new Supplier(supplier.Document, supplier.Description, supplier.Situation, supplier.Id);

        /// <summary>
        /// Habilita fornecedor
        /// </summary>
        public void Enable() => Situation = Situation.Enabled;

        /// <summary>
        /// Desabilita fornecedor
        /// </summary>
        public void Disable() => Situation = Situation.Disabled;

        /// <summary>
        /// Atualiza dados básicos
        /// </summary>
        /// <param name="document">Documento (CNPJ)</param>
        /// <param name="description">Descrição</param>
        public void UpdateBasicData(string document, string description)
        {
            Document = document;
            Description = description;
        }
    }
}
