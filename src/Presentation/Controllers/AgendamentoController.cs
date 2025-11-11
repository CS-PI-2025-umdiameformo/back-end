using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Application.Interfaces;
using OrganizeAgenda.Domain.DTOs;


namespace OrganizeAgenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

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
