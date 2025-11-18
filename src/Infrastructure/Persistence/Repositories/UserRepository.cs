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
        public async Task<IEnumerable<UserDTOResponse>> GetAllAsync()
        {
            var response = _context.Users.AsNoTracking().Select(u => new UserDTOResponse
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                CriadoEm = u.CriadoEm
            });
            return response;
        }

        /// <summary>
        /// Retorna um usuário pelo ID.
        /// </summary>
        public async Task<UserDTOResponse?> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        public async Task<UserDTOResponse> CreateUserAsync(UserDTO user)
        {
            var created = new User
            {
                Nome  = user.Nome,
                Email = user.Email,
                SenhaHash = user.SenhaHash,
                CriadoEm = DateTime.UtcNow
            };

            _context.Users.Add(created);
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

        private UserDTOResponse MapToResponseDTO(UserDTO user)
        {
            return new UserDTOResponse
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                CriadoEm = user.CriadoEm
            };
        }

        private string HashSenha(string senha)
        {
            return "";
        }

    }
}
