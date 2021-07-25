namespace Domain
{
    public class RelatorioMesFormaPagamentoValor
    {
        #region Propriedades

        public string Mes { get; set; }

        public decimal Debito { get; set; }

        public decimal Credito { get; set; }

        public decimal Boleto { get; set; }

        #endregion Propriedades

        #region Construtores

        public RelatorioMesFormaPagamentoValor()
        {
            Mes = string.Empty;
        }

        public RelatorioMesFormaPagamentoValor(string mes)
        {
            Mes = mes;
        }

        #endregion Construtores
    }
}