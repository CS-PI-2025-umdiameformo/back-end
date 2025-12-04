using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Application.Interfaces;
using OrganizeAgenda.Domain.DTOs;


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

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var agendamentos = await _agendamentoService.ListarTodosAsync();
            return Ok(agendamentos);
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
                return NotFound();
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AgendamentoDTO agendamento)
        {
            var id = await _agendamentoService.CriarAsync(agendamento);
            return CreatedAtAction(nameof(ObterPorId), new { id }, agendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AgendamentoDTO agendamento)
        {
            if (agendamento == null || agendamento.Id != id)
                return BadRequest();

            var atualizado = await _agendamentoService.AtualizarAsync(agendamento);
            if (!atualizado)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var removido = await _agendamentoService.RemoverAsync(id);
            if (!removido)
                return NotFound();
            return NoContent();
        }
    }
}
            {
                return NotFound();
            }

            return Ok(agendamento);
        }

        /// <summary>
        /// Atualiza um agendamento existente.
        /// </summary>
        /// <param name="id">Identificador do agendamento.</param>
        /// <param name="agendamento">Dados atualizados do agendamento.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AgendamentoDTO agendamento)
        {
            if (string.IsNullOrWhiteSpace(agendamento.Titulo))
            {
                return BadRequest("O título não pode ser vazio.");
            }

            if (agendamento.DataHora < DateTime.Now)
            {
                return BadRequest("A data do agendamento não pode estar no passado.");
            }

            agendamento.Id = id;
            var atualizado = await _agendamentoService.AtualizarAsync(agendamento);
            if (!atualizado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
