using OrganizeAgenda.DTOs.User;

namespace OrganizeAgenda.Abstractions
{
    /// <summary>
    /// Interface para operações de repositório de usuário.
    /// </summary>
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(UserDTO user);
        Task<bool> UpdateAsync(UserDTO user);
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Verifica se existe usuário com o email informado
        /// </summary>
        /// <param name="email">Email a verificar</param>
        /// <param name="excluirId">ID do usuário a excluir da verificação (para updates)</param>
        Task<bool> ExistePorEmailAsync(string email, int? excluirId = null);

        /// <summary>
        /// Verifica se existe usuário com o CPF informado
        /// </summary>
        /// <param name="cpf">CPF a verificar</param>
        /// <param name="excluirId">ID do usuário a excluir da verificação (para updates)</param>
        Task<bool> ExistePorCpfAsync(string cpf, int? excluirId = null);

        /// <summary>
        /// Verifica se existe usuário com o telefone informado
        /// </summary>
        /// <param name="telefone">Telefone a verificar</param>
        /// <param name="excluirId">ID do usuário a excluir da verificação (para updates)</param>
        Task<bool> ExistePorTelefoneAsync(string telefone, int? excluirId = null);
    }
}
