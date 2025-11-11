using OrganizeAgenda.Application.DTO;
using OrganizeAgenda.Application.Interfaces;
using OrganizeAgenda.Domain.DTOs;
using OrganizeAgenda.Infrastructure.Persistence.Interface;

namespace OrganizeAgenda.Application.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar operações relacionadas a usuários.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Repositório de usuários utilizado para acesso aos dados.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor que recebe uma instância de <see cref="IUserRepository"/>.
        /// </summary>
        /// <param name="userRepository">Repositório de usuários.</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">Dados do usuário a ser criado.</param>
        /// <returns>Usuário criado.</returns>
        public async Task<UserResponseDTO> CreateUserAsync(UserDTO user)
        {
            var createdUser = await _userRepository.CreateUserAsync(user);

            var response = new UserResponseDTO
            {
                Id = createdUser.Id,
                Name = createdUser.Nome,
                Email = createdUser.Email,
                CreatedAt = createdUser.CriadoEm
            };
            return response;
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser deletado.</param>
        /// <returns>Verdadeiro se o usuário foi deletado com sucesso, falso caso contrário.</returns>
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        public async Task<IEnumerable<UserResponseDTO?>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (!users.Any())
            {
                return Enumerable.Empty<UserResponseDTO>();
            }

            var response = users.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Nome,
                Email = user.Email,
                CreatedAt = user.CriadoEm
            });

            return response;
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Usuário correspondente ao ID, ou nulo se não encontrado.</returns>
        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                 return null;
            
            var response = new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Nome,
                Email = user.Email,
                CreatedAt = user.CriadoEm
            };

            return response;
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="user">Dados atualizados do usuário.</param>
        /// <returns>Verdadeiro se a atualização foi bem-sucedida, falso caso contrário.</returns>
        public async Task<bool> UpdateUserAsync(int user)
        {
            UserDTO? usuario = await _userRepository.GetByIdAsync(user);

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            UserDTO newuser = new UserDTO();
            return await _userRepository.UpdateAsync(newuser);
        }
    }
}
