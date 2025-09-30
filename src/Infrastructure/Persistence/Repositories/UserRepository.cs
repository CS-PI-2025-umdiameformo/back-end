using Microsoft.EntityFrameworkCore;
using OrganizeAgenda.Domain.DTOs;
using OrganizeAgenda.Infrastructure.Persistence.Interface;

namespace OrganizeAgenda.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repositório para operações de usuário utilizando Entity Framework.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="UserRepository"/>.
        /// </summary>
        /// <param name="context">DbContext do Entity Framework.</param>
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retorna um usuário pelo ID.
        /// </summary>
        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        public async Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        public async Task<bool> UpdateAsync(UserDTO user)
        {
            _context.Users.Update(user);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        /// <summary>
        /// Remove um usuário pelo ID.
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }
    }
}
