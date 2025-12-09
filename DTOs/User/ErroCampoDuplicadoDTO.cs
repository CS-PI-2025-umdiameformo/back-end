namespace OrganizeAgenda.DTOs.User
{
    /// <summary>
    /// DTO de resposta para indicar campo duplicado
    /// </summary>
    public class ErroCampoDuplicadoDTO
    {
        /// <summary>
        /// Indica se há duplicidade
        /// </summary>
        public bool Duplicado { get; set; }

        /// <summary>
        /// Nome do campo duplicado (Email, CPF ou Telefone)
        /// </summary>
        public string Campo { get; set; } = string.Empty;

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Mensagem { get; set; } = string.Empty;
    }
}
