using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Abstractions;

namespace OrganizeAgenda.Controllers
{
    /// <summary>
    /// Controller responsável por operações relacionadas a agendamentos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        /// <summary>
        /// Construtor que injeta o serviço de agendamentos.
        /// </summary>
        /// <param name="agendamentoService">Serviço de agendamentos.</param>
        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        /// <summary>
        /// Obtém os detalhes de um agendamento específico.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <returns>Dados do agendamento.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var agendamento = await _agendamentoService.ObterPorIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return Ok(agendamento);
        }
    }
}