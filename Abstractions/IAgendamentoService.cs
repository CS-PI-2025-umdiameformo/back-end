using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Abstractions
{
    /// <summary>
    /// Interface para serviços de agendamento.
    /// </summary>
    public interface IAgendamentoService
    {
        /// <summary>
        /// Cria um novo agendamento.
        /// </summary>
        /// <param name="agendamento">Dados do agendamento.</param>
        /// <returns>Id do agendamento criado.</returns>
        Task<int> CriarAsync(AgendamentoDTO agendamento);

        /// <summary>
        /// Retorna todos os agendamentos.
        /// </summary>
        /// <returns>Lista de agendamentos.</returns>
        Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync();

        /// <summary>
        /// Retorna um agendamento pelo id.
        /// </summary>
        /// <param name="id">Id do agendamento.</param>
        /// <returns>Agendamento encontrado ou null.</returns>
        Task<AgendamentoDTO?> ObterPorIdAsync(int id);

        /// <summary>
        /// Atualiza um agendamento existente.
        /// </summary>
        /// <param name="agendamento">Dados do agendamento.</param>
        /// <returns>True se atualizado com sucesso.</returns>
        Task<bool> AtualizarAsync(AgendamentoDTO agendamento);

        /// <summary>
        /// Remove um agendamento pelo id.
        /// </summary>
        /// <param name="id">Id do agendamento.</param>
        /// <returns>True se removido com sucesso.</returns>
        Task<bool> RemoverAsync(int id);
    }
}
