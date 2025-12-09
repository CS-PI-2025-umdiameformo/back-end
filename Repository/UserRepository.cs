using Microsoft.EntityFrameworkCore;
using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs.User;

namespace OrganizeAgenda.Repository
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

        /// <summary>
        /// Verifica se existe usuário com o email informado
        /// </summary>
        public async Task<bool> ExistePorEmailAsync(string email, int? excluirId = null)
        {
            var query = _context.Users.AsNoTracking().Where(u => u.Email == email);
            
            if (excluirId.HasValue)
                query = query.Where(u => u.Id != excluirId.Value);
            
            return await query.AnyAsync();
        }

        /// <summary>
        /// Verifica se existe usuário com o CPF informado
        /// </summary>
        public async Task<bool> ExistePorCpfAsync(string cpf, int? excluirId = null)
        {
            // Por enquanto retorna false pois UserDTO não tem CPF
            return await Task.FromResult(false);
        }

        /// <summary>
        /// Verifica se existe usuário com o telefone informado
        /// </summary>
        public async Task<bool> ExistePorTelefoneAsync(string telefone, int? excluirId = null)
        {
            // Por enquanto retorna false pois UserDTO não tem Telefone
            return await Task.FromResult(false);
        }
    }
}
