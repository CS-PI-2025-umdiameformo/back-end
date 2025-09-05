using OrganizeAgenda.DTOs;

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
    }
}