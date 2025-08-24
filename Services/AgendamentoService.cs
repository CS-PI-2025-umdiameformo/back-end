using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Services
{
    /// <summary>
    /// Implementação dos serviços de agendamento.
    /// </summary>
    public class AgendamentoService : IAgendamentoService
    {
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
        public Task<int> CriarAsync(AgendamentoDTO agendamento)
        {
            agendamento.Id = _proximoId++;
            _agendamentos.Add(agendamento);
            return Task.FromResult(agendamento.Id);
        }

        /// <summary>
        /// Lista todos os agendamentos armazenados.
        /// </summary>
        /// <returns>Coleção de agendamentos.</returns>
        public Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync()
        {
            return Task.FromResult<IEnumerable<AgendamentoDTO>>(_agendamentos);
        }

        /// <summary>
        /// Obtém os detalhes de um agendamento específico.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <returns>Agendamento encontrado ou null.</returns>
        public Task<AgendamentoDTO?> ObterPorIdAsync(int id)
        {
            var agendamento = _agendamentos.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(agendamento);
        }

        /// <summary>
        /// Atualiza um agendamento existente.
        /// </summary>
        /// <param name="agendamento">Dados atualizados do agendamento.</param>
        /// <returns>True se atualizado com sucesso.</returns>
        public Task<bool> AtualizarAsync(AgendamentoDTO agendamento)
        {
            var indice = _agendamentos.FindIndex(a => a.Id == agendamento.Id);
            if (indice == -1)
            {
                return Task.FromResult(false);
            }

            _agendamentos[indice] = agendamento;
            return Task.FromResult(true);
        }

        /// <summary>
        /// Remove um agendamento pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <returns>True se removido com sucesso.</returns>
        public Task<bool> RemoverAsync(int id)
        {
            var agendamento = _agendamentos.FirstOrDefault(a => a.Id == id);
            if (agendamento == null)
            {
                return Task.FromResult(false);
            }

            _agendamentos.Remove(agendamento);
            return Task.FromResult(true);
        }
    }
}
