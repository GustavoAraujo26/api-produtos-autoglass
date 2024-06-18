using System.ComponentModel;

namespace AutoGlassProducts.Domain.Enums
{
    /// <summary>
    /// Status da entidade/modelo
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Habilitado
        /// </summary>
        [Description("Enabled")]
        Enabled = 1,
        /// <summary>
        /// Desabilitado
        /// </summary>
        [Description("Disabled")]
        Disabled = 2
    }
}
