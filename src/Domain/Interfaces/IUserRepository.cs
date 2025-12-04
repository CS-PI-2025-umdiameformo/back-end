using OrganizeAgenda.Domain.DTOs;

namespace OrganizeAgenda.Infrastructure.Persistence.Interface
{
    /// <summary>
    /// Interface para operações de repositório de usuário.
    /// </summary>
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTOResponse>> GetAllAsync();
        Task<UserDTOResponse?> GetByIdAsync(int id);
        Task<UserDTOResponse> CreateUserAsync(UserDTO user);
        Task<bool> UpdateAsync(UserDTO user);
        Task<bool> DeleteAsync(int id);
    }
}