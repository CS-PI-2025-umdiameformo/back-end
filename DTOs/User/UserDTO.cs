namespace OrganizeAgenda.DTOs.User
{
    /// <summary>
    /// Data Transfer Object para informações do usuário.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Hash da senha do usuário.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora em que o usuário foi criado (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
