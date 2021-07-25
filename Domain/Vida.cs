using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Vida
    {
        #region Propriedades

        [Key]
        public int IdVida { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Endereço Residencial")]
        public string? EnderecoResidencial { get; set; }

        [Display(Name = "Endereço Comercial")]
        public string? EnderecoComercial { get; set; }

        [Display(Name = "Telefones")]
        public string? Telefones { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Display(Name = "Profissão")]
        public string? Profissao { get; set; }

        [ForeignKey("IdVida")]
        [Display(Name = "Segurado Principal")]
        public int? IdSeguradoPrincipal { get; set; }

        [Display(Name = "Data do Cancelamento")]
        public DateTime? DataCancelamento { get; set; }

        [NotMapped]
        public List<Vida> VidasPossiveis { get; set; }

        #endregion Propriedades

        #region Construtores

        public Vida()
        {
            IdVida = 0;
            Nome = string.Empty;
            DataNascimento = DateTime.Now;
            Sexo = string.Empty;
            Tipo = string.Empty;
            CPF = string.Empty;
            VidasPossiveis = new List<Vida>();
        }

        public Vida(int idVida, string nome, DateTime dataNascimento, string sexo, string tipo, string cPF)
        {
            IdVida = idVida;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Tipo = tipo;
            CPF = cPF;
            VidasPossiveis = new List<Vida>();
        }

        public Vida(int idVida, string nome, DateTime dataNascimento, string sexo, string tipo, string cPF, string? enderecoResidencial = null, string? enderecoComercial = null, string? telefones = null, string? email = null
            , string? profissao = null, int? idSeguradoPrincipal = null)
        {
            IdVida = idVida;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Tipo = tipo;
            CPF = cPF;
            EnderecoResidencial = enderecoResidencial;
            EnderecoComercial = enderecoComercial;
            Telefones = telefones;
            Email = email;
            Profissao = profissao;
            IdSeguradoPrincipal = idSeguradoPrincipal;
            VidasPossiveis = new List<Vida>();
        }

        public Vida(int idVida, string nome, DateTime dataNascimento, string sexo, string tipo, string cPF, string? enderecoResidencial = null, string? enderecoComercial = null, string? telefones = null, string? email = null
            , string? profissao = null, int? idSeguradoPrincipal = null, List<Vida>? vidasPossiveis = null)
        {
            IdVida = idVida;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Tipo = tipo;
            CPF = cPF;
            EnderecoResidencial = enderecoResidencial;
            EnderecoComercial = enderecoComercial;
            Telefones = telefones;
            Email = email;
            Profissao = profissao;
            IdSeguradoPrincipal = idSeguradoPrincipal;
            VidasPossiveis = vidasPossiveis ?? new List<Vida>();
        }

        #endregion Construtores
    }
}