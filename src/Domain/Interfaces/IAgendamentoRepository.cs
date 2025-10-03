using OrganizeAgenda.Domain.DTOs;

namespace OrganizeAgenda.Infrastructure.Persistence.Interface
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
    }
}