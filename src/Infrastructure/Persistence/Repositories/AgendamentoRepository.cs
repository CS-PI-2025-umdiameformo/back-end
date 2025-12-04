using Microsoft.EntityFrameworkCore;
using OrganizeAgenda.Domain.DTOs;
using OrganizeAgenda.Infrastructure.Persistence;
using OrganizeAgenda.Infrastructure.Persistence.Interface;

namespace OrganizeAgenda.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repositório para operações de agendamento utilizando Entity Framework.
    /// </summary>
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AppDbContext _context;

        public AgendamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(AgendamentoDTO agendamento)
        {
            // acessar qual usuário e associar ao agendamento no futuro

            Agendamento a = new Agendamento
            {
                DataHora = agendamento.DataHora,
                Descricao = agendamento.Descricao,
                Titulo = agendamento.Titulo,
                UsuarioId = agendamento.UsuarioId,
            };

            var agendado = _context.Agendamentos.Add(a);
            await _context.SaveChangesAsync();
            return agendado.Entity.Id;
        }

        public async Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync()
        {
            return await _context.Agendamentos
                .AsNoTracking()
                .Select(a => new AgendamentoDTO
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    DataHora = a.DataHora,
                    Descricao = a.Descricao,
                    UsuarioId = a.UsuarioId
                })
                .ToListAsync();
        }

        public async Task<AgendamentoDTO?> ObterPorIdAsync(int id)
        {
            var a = await _context.Agendamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (a == null)
                return null;

            return new AgendamentoDTO
            {
                Id = a.Id,
                Titulo = a.Titulo,
                DataHora = a.DataHora,
                Descricao = a.Descricao,
                UsuarioId = a.UsuarioId
            };
        }

        public async Task<bool> AtualizarAsync(AgendamentoDTO agendamento)
        {
            var entity = await _context.Agendamentos.FindAsync(agendamento.Id);
            if (entity == null)
                return false;

            entity.Titulo = agendamento.Titulo;
            entity.DataHora = agendamento.DataHora;
            entity.Descricao = agendamento.Descricao;
            entity.UsuarioId = agendamento.UsuarioId;

            _context.Agendamentos.Update(entity);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
                return false;

            _context.Agendamentos.Remove(agendamento);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }
    }
}