using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object para informações de agendamento.
    /// </summary>
    public class AgendamentoDTO
    {

        /// <summary>
        /// Identificador do agendamento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador único do agendamento.
        /// </summary>

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
        /// Usuário que criou o agendamento.
        /// </summary>
        public UserDTO Usuario { get; set; } = new UserDTO();

        /// <summary>
        /// Tipo de recorrência do agendamento.
        /// </summary>
        public TipoRecorrencia Recorrencia { get; set; } = TipoRecorrencia.Nenhuma;
    }
}
