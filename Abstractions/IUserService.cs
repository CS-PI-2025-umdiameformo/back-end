using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">O ID do usuário.</param>
        /// <returns>O usuário correspondente ao ID.</returns>
        Task<UserDTO?> GetUserByIdAsync(int id);

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">Os dados do usuário a serem criados.</param>
        /// <returns>O usuário criado.</returns>
        Task<UserDTO> CreateUserAsync(UserDTO user);

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">O ID do usuário a ser atualizado.</param>
        /// <param name="user">Os novos dados do usuário.</param>
        Task<bool> UpdateUserAsync(UserDTO user);

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser deletado.</param>
        Task<bool> DeleteUserAsync(int id);
    }
}
