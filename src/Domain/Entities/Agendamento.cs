namespace OrganizeAgenda.Domain.Entities
{
    /// <summary>
    /// Data Transfer Object para informações de agendamento.
    /// </summary>
    public class Agendamento
    {
        /// <summary>
        /// Identificador único do agendamento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do agendamento.
        /// </summary>
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora do agendamento.
        /// </summary>
        public DateTime DataHora { get; set; }

        /// <summary>
        /// Descrição do agendamento.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Ef solicitou
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuário que criou o agendamento.
        /// </summary>
        public User Usuario { get; set; } = new User();
    }
}
