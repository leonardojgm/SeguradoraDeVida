namespace Domain
{
    public class RelatorioCidadeVidas
    {
        #region Propriedades

        public string Cidade { get; set; }

        public int Quantidade { get; set; }

        #endregion Propriedades

        #region Construtores

        public RelatorioCidadeVidas()
        {
            Cidade = string.Empty;
        }

        public RelatorioCidadeVidas(string cidade)
        {
            Cidade = cidade;
        }

        #endregion Construtores
    }
}