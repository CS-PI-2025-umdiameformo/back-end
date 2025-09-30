using OrganizeAgenda.Domain.DTOs;

namespace OrganizeAgenda.Application.Interfaces
{
    /// <summary>
    /// Interface para serviços de agendamento.
    /// </summary>
    public interface IAgendamentoService
    {
        Task<int> CriarAsync(AgendamentoDTO agendamento);
        Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync();
        Task<AgendamentoDTO?> ObterPorIdAsync(int id);
        Task<bool> AtualizarAsync(AgendamentoDTO agendamento);
        Task<bool> RemoverAsync(int id);
    }
}
