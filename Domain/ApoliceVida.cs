using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ApoliceVida
    {
        #region Propriedades

        [Key]
        public int IdApoliceVida { get; set; }


        [ForeignKey("Apolice")]
        [Display(Name = "Id Apólice")]
        public int IdApolice { get; set; }


        [ForeignKey("Vida")]
        [Display(Name = "Id Vida")]
        public int IdVida { get; set; }

        [Display(Name = "Data do Cancelamento")]
        public DateTime? DataCancelamento { get; set; }

        [NotMapped]
        public List<Vida> VidasPossiveis { get; set; }

        [NotMapped]
        public List<Apolice> ApolicesPossiveis { get; set; }

        #endregion Propriedades

        #region Contrutores

        public ApoliceVida()
        {
            VidasPossiveis = new List<Vida>();
            ApolicesPossiveis = new List<Apolice>();
        }

        public ApoliceVida(int idApoliceVida, int idApolice, int idVida)
        {
            IdApoliceVida = idApoliceVida;
            IdApolice = idApolice;
            IdVida = idVida;
            VidasPossiveis = new List<Vida>();
            ApolicesPossiveis = new List<Apolice>();
        }

        public ApoliceVida(int idApoliceVida, int idApolice, int idVida, List<Vida>? vidasPossiveis = null, List<Apolice>? apolicesPossiveis = null)
        {
            IdApoliceVida = idApoliceVida;
            IdApolice = idApolice;
            IdVida = idVida;
            VidasPossiveis = vidasPossiveis ?? new List<Vida>();
            ApolicesPossiveis = apolicesPossiveis ?? new List<Apolice>();
        }

        #endregion Construtores
    }
}