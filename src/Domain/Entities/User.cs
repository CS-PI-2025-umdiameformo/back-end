using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OrganizeAgenda.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTo) para informações do usuário.
    /// </summary>
    public record User
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public User()
        { }

        /// <summary>
        /// Construtor parametrizado
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="senha">Senha ou hash da senha do usuário.</param>
        public User(string nome, string email, string senha)
        {
            Nome = nome ?? string.Empty;
            Email = email ?? string.Empty;
            SenhaHash = senha ?? string.Empty;
            CriadoEm = DateTime.UtcNow;
            Agendamentos = new List<Agendamento>();
        }

        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Hash da senha do usuário.
        /// </summary>
        public string SenhaHash { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora em que o usuário foi criado (UTC).
        /// </summary>
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Agendamentos do usuário.
        /// </summary>
        public ICollection<Agendamento>? Agendamentos { get; set; } = new List<Agendamento>();
    }
}
