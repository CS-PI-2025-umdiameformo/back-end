namespace OrganizeAgenda.Utils
{
    /// <summary>
    /// Classe para padronização de dados antes de validações
    /// </summary>
    public static class NormalizadorDados
    {
        /// <summary>
        /// Normaliza CPF removendo tudo exceto dígitos
        /// </summary>
        public static string NormalizarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;

            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Normaliza telefone removendo tudo exceto dígitos
        /// </summary>
        public static string NormalizarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return string.Empty;

            return new string(telefone.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Normaliza email convertendo para minúsculas e removendo espaços
        /// </summary>
        public static string NormalizarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return string.Empty;

            return email.Trim().ToLowerInvariant();
        }
    }
}
