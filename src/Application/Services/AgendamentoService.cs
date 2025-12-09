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

        /// <summary>
        /// Lista em memória utilizada como armazenamento temporário dos agendamentos.
        /// </summary>
        private static readonly List<AgendamentoDTO> _agendamentos = new();

        /// <summary>
        /// Controle para geração de identificadores dos agendamentos.
        /// </summary>
        private static int _proximoId = 1;

        /// <summary>
        /// Cria um novo agendamento e o armazena na lista em memória.
        /// </summary>
        /// <param name="agendamento">Dados do agendamento.</param>
        /// <returns>Identificador do agendamento criado.</returns>
        public async Task<int> CriarAsync(AgendamentoDTO agendamento)
        {
            if (agendamento is null)
                throw new ArgumentNullException(nameof(agendamento));

            if (agendamento.DataHora <= DateTime.Now)
                throw new ArgumentException("A data e hora do agendamento deve ser futura.");

            if (string.IsNullOrWhiteSpace(agendamento.Titulo))
                throw new ArgumentException("O agendamento deve possuir um título.");

            var user = _httpContextAccessor.HttpContext?.User;
            var usuarioId = user?.GetUserIdAsInt();
            if (usuarioId == null)
                throw new InvalidOperationException("User id não encontrado nos claims.");

            agendamento.Usuario = new UserDTO { Id = usuarioId.Value };
            return await _agendamentoRepository.CriarAsync(agendamento);

        }

        /// <summary>
        /// Lista todos os agendamentos armazenados.
        /// </summary>
        /// <returns>Coleção de agendamentos.</returns>
        public async Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync()
        {
            return await _agendamentoRepository.ListarTodosAsync();
        }

        /// <summary>
        /// Obtém os detalhes de um agendamento específico.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <returns>Agendamento encontrado ou null.</returns>
        public async Task<AgendamentoDTO?> ObterPorIdAsync(int id)
        {
            return await _agendamentoRepository.ObterPorIdAsync(id);
        }

        /// <summary>
        /// Atualiza um agendamento existente.
        /// </summary>
        /// <param name="agendamento">Dados atualizados do agendamento.</param>
        /// <returns>True se atualizado com sucesso.</returns>
        public async Task<bool> AtualizarAsync(AgendamentoDTO agendamento)
        {
            if (agendamento is null)
                return false;

            if (string.IsNullOrWhiteSpace(agendamento.Titulo) || agendamento.DataHora < DateTime.Now)
            {
                return false;
            }

            // Delegate update to repository
            return await _agendamentoRepository.AtualizarAsync(agendamento);
        }

        /// <summary>
        /// Remove um agendamento pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <returns>True se removido com sucesso.</returns>
        public async Task<bool> RemoverAsync(int id)
        {
            return await _agendamentoRepository.RemoverAsync(id);
        }
    }
}
