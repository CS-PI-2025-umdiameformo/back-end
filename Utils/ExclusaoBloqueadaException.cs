namespace OrganizeAgenda.Utils
{
    /// <summary>
    /// Exception lançada quando a exclusão é bloqueada por vínculos
    /// </summary>
    public class ExclusaoBloqueadaException : Exception
    {
        /// <summary>
        /// Quantidade de agendamentos vinculados
        /// </summary>
        public int QuantidadeAgendamentos { get; }

        public ExclusaoBloqueadaException(int quantidadeAgendamentos, string mensagem) : base(mensagem)
        {
            QuantidadeAgendamentos = quantidadeAgendamentos;
        }
    }
}
