using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Abstractions
{
    /// <summary>
    /// Interface para repositório de agendamento.
    /// </summary>
    public interface IAgendamentoRepository
    {
        Task<int> CriarAsync(AgendamentoDTO agendamento);
        Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync();
        Task<AgendamentoDTO?> ObterPorIdAsync(int id);
        Task<bool> AtualizarAsync(AgendamentoDTO agendamento);
        Task<bool> RemoverAsync(int id);

        /// <summary>
        /// Conta quantos agendamentos um usuário possui
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        Task<int> ContarPorUsuarioAsync(int usuarioId);
    }
}
