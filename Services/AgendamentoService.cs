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
            if (agendamento.DataHora <= DateTime.Now)
                throw new ArgumentException("A data e hora do agendamento deve ser futura.");
            
            if (string.IsNullOrWhiteSpace(agendamento.Titulo))
                throw new ArgumentException("O agendamento deve possuir um título.");

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
