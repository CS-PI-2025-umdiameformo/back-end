namespace OrganizeAgenda.DTOs
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
    }
}
