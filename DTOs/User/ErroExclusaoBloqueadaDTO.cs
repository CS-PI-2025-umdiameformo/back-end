namespace OrganizeAgenda.DTOs.User
{
    /// <summary>
    /// DTO de resposta para exclusão bloqueada
    /// </summary>
    public class ErroExclusaoBloqueadaDTO
    {
        /// <summary>
        /// Indica se a exclusão está bloqueada
        /// </summary>
        public bool Bloqueado { get; set; }

        /// <summary>
        /// Quantidade de agendamentos vinculados
        /// </summary>
        public int QuantidadeAgendamentos { get; set; }

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Mensagem { get; set; } = string.Empty;
    }
}
