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
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return agendamento.Id;
        }

        public async Task<IEnumerable<AgendamentoDTO>> ListarTodosAsync()
        {
            return await _context.Agendamentos.AsNoTracking().ToListAsync();
        }

        public async Task<AgendamentoDTO?> ObterPorIdAsync(int id)
        {
            return await _context.Agendamentos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> AtualizarAsync(AgendamentoDTO agendamento)
        {
            _context.Agendamentos.Update(agendamento);
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