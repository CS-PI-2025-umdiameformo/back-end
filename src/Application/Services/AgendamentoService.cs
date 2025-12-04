using Microsoft.AspNetCore.Http;
using OrganizeAgenda.Application.Extensions;
using OrganizeAgenda.Application.Interfaces;
using OrganizeAgenda.Domain.DTOs;
using OrganizeAgenda.Infrastructure.Persistence.Interface;

namespace OrganizeAgenda.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de agendamento.
    /// </summary>
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IHttpContextAccessor context)
        {
            _agendamentoRepository = agendamentoRepository;
            _httpContextAccessor = context;
        }

        public async Task<int> CriarAsync(AgendamentoDTO agendamento)
        {
            if (agendamento.DataHora <= DateTime.Now)
                throw new ArgumentException("A data e hora do agendamento deve ser futura.");
            
            if (string.IsNullOrWhiteSpace(agendamento.Titulo))
                throw new ArgumentException("O agendamento deve possuir um título.");

            var user = _httpContextAccessor.HttpContext?.User;

            var usuarioId = user?.GetUserIdAsInt();
            if (usuarioId == null)
                throw new InvalidOperationException("User id não encontrado nos claims.");

            agendamento.UsuarioId = usuarioId.Value;
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
