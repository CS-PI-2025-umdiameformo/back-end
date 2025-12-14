namespace OrganizeAgenda.Utils
{
    /// <summary>
    /// Exception lançada quando um campo duplicado é detectado
    /// </summary>
    public class DuplicidadeException : Exception
    {
        /// <summary>
        /// Nome do campo duplicado
        /// </summary>
        public string Campo { get; }

        public DuplicidadeException(string campo, string mensagem) : base(mensagem)
        {
            Campo = campo;
        }
    }
}
