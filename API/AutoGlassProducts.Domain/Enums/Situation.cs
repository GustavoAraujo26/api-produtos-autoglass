using System.ComponentModel;

namespace AutoGlassProducts.Domain.Enums
{
    /// <summary>
    /// Situação da entidade/modelo
    /// </summary>
    public enum Situation
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
