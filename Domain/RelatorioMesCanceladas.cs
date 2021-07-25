namespace Domain
{
    public class RelatorioMesCanceladas
    {
        #region Propriedades

        public string Mes { get; set; }

        public int Quantidade { get; set; }

        #endregion Propriedades

        #region Construtores

        public RelatorioMesCanceladas()
        {
            Mes = string.Empty;
        }

        public RelatorioMesCanceladas(string mes)
        {
            Mes = mes;
        }

        #endregion Construtores
    }
}