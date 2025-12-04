namespace OrganizeAgenda.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTo) para informações do usuário.
    /// </summary>
    public class UserDTOResponse
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora em que o usuário foi criado (UTC).
        /// </summary>
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Agendamentos do usuário.
        /// </summary>
        public ICollection<AgendamentoDTO>? Agendamentos { get; set; } = new List<AgendamentoDTO>();
    }
}
