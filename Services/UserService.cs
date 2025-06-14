using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;

namespace OrganizeAgenda.Services
{
    public class UserService : IUserService
    {
        public Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
