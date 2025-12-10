using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs.User;
using OrganizeAgenda.Utils;

namespace OrganizeAgenda.Services
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
        public async Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            await ValidarDuplicidade(user, null);
            var createdUser = await _userRepository.CreateUserAsync(user);
            return createdUser;
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
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Usuário correspondente ao ID, ou nulo se não encontrado.</returns>
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="user">Dados atualizados do usuário.</param>
        /// <returns>Verdadeiro se a atualização foi bem-sucedida, falso caso contrário.</returns>
        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            await ValidarDuplicidade(user, user.Id);
            return await _userRepository.UpdateAsync(user);
        }

        /// <summary>
        /// Valida se há campos duplicados
        /// </summary>
        private async Task ValidarDuplicidade(UserDTO user, int? excluirId)
        {
            // Normaliza e valida email
            var emailNormalizado = NormalizadorDados.NormalizarEmail(user.Email);
            if (await _userRepository.ExistePorEmailAsync(emailNormalizado, excluirId))
            {
                throw new DuplicidadeException("Email", "Este email já está cadastrado");
            }

            // Validação de CPF
            if (!string.IsNullOrWhiteSpace(user.Cpf))
            {
                var cpfNormalizado = NormalizadorDados.NormalizarCpf(user.Cpf);
                if (await _userRepository.ExistePorCpfAsync(cpfNormalizado, excluirId))
                {
                    throw new DuplicidadeException("CPF", "Este CPF já está cadastrado");
                }
            }

            // Validação de Telefone
            if (!string.IsNullOrWhiteSpace(user.Telefone))
            {
                var telefoneNormalizado = NormalizadorDados.NormalizarTelefone(user.Telefone);
                if (await _userRepository.ExistePorTelefoneAsync(telefoneNormalizado, excluirId))
                {
                    throw new DuplicidadeException("Telefone", "Este telefone já está cadastrado");
                }
            }
        }
    }
}
