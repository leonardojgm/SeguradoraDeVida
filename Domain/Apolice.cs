using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Domain
{
    public class Apolice
    {
        #region Propriedades

        [Key]
        public int IdApolice { get; set; }


        [Display(Name = "Forma de Pagamento")]
        public string FormaPagamento { get; set; }


        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }


        [Display(Name = "Vigência")]
        public DateTime Vigencia { get; set; }


        [Display(Name = "Data do Pagamento")]
        public DateTime? DataPagamento { get; set; }


        [Display(Name = "Valor")]
        public decimal Valor { get; set; }


        [Display(Name = "Data do Cancelamento")]
        public DateTime? DataCancelamento { get; set; }

        #endregion Propriedades

        #region Contrutores

        public Apolice()
        {
            IdApolice = 0;
            FormaPagamento = string.Empty;
            DataInicio = DateTime.MinValue;
            Vigencia = DateTime.MinValue;
            Valor = 0;
        }

        public Apolice(int idApolice, string formaPagamento, DateTime dataInicio, DateTime vigencia, decimal valor)
        {
            IdApolice = idApolice;
            FormaPagamento = formaPagamento;
            DataInicio = dataInicio;
            Vigencia = vigencia;
            Valor = valor;
        }

        public Apolice(int idApolice, string formaPagamento, DateTime dataInicio, DateTime vigencia, decimal valor, DateTime? dataPagamento = null, DateTime? dataCancelamento = null)
        {
            IdApolice = idApolice;
            FormaPagamento = formaPagamento;
            DataInicio = dataInicio;
            Vigencia = vigencia;
            Valor = valor;
            DataPagamento = dataPagamento ?? null;
            DataCancelamento = dataCancelamento ?? null;
        }

        #endregion Construtores
    }
}