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
        private readonly IUserRepository _userRepository;
        private readonly IAgendamentoRepository _agendamentoRepository;

        /// <summary>
        /// Construtor que recebe as dependências necessárias
        /// </summary>
        public UserService(IUserRepository userRepository, IAgendamentoRepository agendamentoRepository)
        {
            _userRepository = userRepository;
            _agendamentoRepository = agendamentoRepository;
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        public async Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            await ValidarDuplicidade(user, null);
            var createdUser = await _userRepository.CreateUserAsync(user);
            return createdUser;
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            // Verifica se há agendamentos vinculados
            var quantidadeAgendamentos = await _agendamentoRepository.ContarPorUsuarioAsync(id);
            
            if (quantidadeAgendamentos > 0)
            {
                throw new ExclusaoBloqueadaException(
                    quantidadeAgendamentos,
                    $"Não é possível excluir o usuário. Existem {quantidadeAgendamentos} agendamento(s) vinculado(s)."
                );
            }

            return await _userRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
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
