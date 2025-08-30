using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Services
{
    /// <summary>
    /// Implementação dos serviços de agendamento.
    /// </summary>
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<int> CriarAsync(AgendamentoDTO agendamento)
        {
            return await _agendamentoRepository.CriarAsync(agendamento);
        }

        public async Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync()
        {
            return await _agendamentoRepository.ListarTodosAsync();
        }

        public async Task<AgendamentoDTO?> ObterPorIdAsync(int id)
        {
            return await _agendamentoRepository.ObterPorIdAsync(id);
        }

        public async Task<bool> AtualizarAsync(AgendamentoDTO agendamento)
        {
            return await _agendamentoRepository.AtualizarAsync(agendamento);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            return await _agendamentoRepository.RemoverAsync(id);
        }
    }
}
