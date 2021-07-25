using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Relatorios
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Context _context;

        public IndexModel(Repository.Context context)
        {
            _context = context;
        }

        public IList<Apolice> Apolice { get; set; }

        public IList<Vida> Vida { get; set; }

        public IList<RelatorioMesCanceladas> MesCanceladas { get; set; }

        public IList<RelatorioMesFormaPagamentoValor> MesFormaPagamentoValor { get; set; }

        public IList<RelatorioCidadeVidas> CidadeVidas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Apolice = await _context.Apolice.ToListAsync();
            Vida = await _context.Vida.ToListAsync();

            if (Apolice == null)
            {
                return NotFound();
            }

            MesCanceladas = new List<RelatorioMesCanceladas> 
            {
                new RelatorioMesCanceladas
                {
                    Mes = "Janeiro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,1,1) && x.DataCancelamento <= new DateTime(2021,1,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Fevereiro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,2,1) && x.DataCancelamento <= new DateTime(2021,2,28,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Março/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,3,1) && x.DataCancelamento <= new DateTime(2021,3,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Abril/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,4,1) && x.DataCancelamento <= new DateTime(2021,4,30,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Maio/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,5,1) && x.DataCancelamento <= new DateTime(2021,5,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Junho/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,6,1) && x.DataCancelamento <= new DateTime(2021,6,30,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Julho/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,7,1) && x.DataCancelamento <= new DateTime(2021,7,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Agosto/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,8,1) && x.DataCancelamento <= new DateTime(2021,8,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Setembro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,9,1) && x.DataCancelamento <= new DateTime(2021,9,30,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Outubro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,10,1) && x.DataCancelamento <= new DateTime(2021,10,31,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Novembro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,11,1) && x.DataCancelamento <= new DateTime(2021,11,30,23,59,59))
                },
                new RelatorioMesCanceladas
                {
                    Mes = "Dezembro/21",
                    Quantidade = Apolice.Count(x => x.DataCancelamento != null && x.DataCancelamento >= new DateTime(2021,12,1) && x.DataCancelamento <= new DateTime(2021,12,31,23,59,59))
                }
            };

            MesFormaPagamentoValor = new List<RelatorioMesFormaPagamentoValor> 
            {
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Janeiro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,1,1) && x.DataInicio <= new DateTime(2021,1,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,1,1) && x.DataInicio <= new DateTime(2021,1,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,1,1) && x.DataInicio <= new DateTime(2021,1,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Fevereiro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,2,1) && x.DataInicio <= new DateTime(2021,2,28,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,2,1) && x.DataInicio <= new DateTime(2021,2,28,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,2,1) && x.DataInicio <= new DateTime(2021,2,28,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Março/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,3,1) && x.DataInicio <= new DateTime(2021,3,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,3,1) && x.DataInicio <= new DateTime(2021,3,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,3,1) && x.DataInicio <= new DateTime(2021,3,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Abril/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,4,1) && x.DataInicio <= new DateTime(2021,4,30,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,4,1) && x.DataInicio <= new DateTime(2021,4,30,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,4,1) && x.DataInicio <= new DateTime(2021,4,30,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Maio/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,5,1) && x.DataInicio <= new DateTime(2021,5,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,5,1) && x.DataInicio <= new DateTime(2021,5,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,5,1) && x.DataInicio <= new DateTime(2021,5,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Junho/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,6,1) && x.DataInicio <= new DateTime(2021,6,30,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,6,1) && x.DataInicio <= new DateTime(2021,6,30,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,6,1) && x.DataInicio <= new DateTime(2021,6,30,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Julho/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,7,1) && x.DataInicio <= new DateTime(2021,7,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,7,1) && x.DataInicio <= new DateTime(2021,7,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,7,1) && x.DataInicio <= new DateTime(2021,7,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Agosto/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,8,1) && x.DataInicio <= new DateTime(2021,8,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,8,1) && x.DataInicio <= new DateTime(2021,8,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,8,1) && x.DataInicio <= new DateTime(2021,8,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Setembro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,9,1) && x.DataInicio <= new DateTime(2021,9,30,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,9,1) && x.DataInicio <= new DateTime(2021,9,30,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,9,1) && x.DataInicio <= new DateTime(2021,9,30,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Outubro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,10,1) && x.DataInicio <= new DateTime(2021,10,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,10,1) && x.DataInicio <= new DateTime(2021,10,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,10,1) && x.DataInicio <= new DateTime(2021,10,31,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Novembro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,11,1) && x.DataInicio <= new DateTime(2021,11,30,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,11,1) && x.DataInicio <= new DateTime(2021,11,30,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,11,1) && x.DataInicio <= new DateTime(2021,11,30,23,59,59)).Sum(x => x.Valor)
                },
                new RelatorioMesFormaPagamentoValor
                {
                    Mes = "Dezembro/21",
                    Credito = Apolice.Where(x => x.FormaPagamento == "Débito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,12,1) && x.DataInicio <= new DateTime(2021,12,31,23,59,59)).Sum(x => x.Valor),
                    Debito = Apolice.Where(x => x.FormaPagamento == "Cartão de crédito" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,12,1) && x.DataInicio <= new DateTime(2021,12,31,23,59,59)).Sum(x => x.Valor),
                    Boleto = Apolice.Where(x => x.FormaPagamento == "Boleto" && x.DataPagamento == null && x.DataInicio >= new DateTime(2021,12,1) && x.DataInicio <= new DateTime(2021,12,31,23,59,59)).Sum(x => x.Valor)
                }
            };

            CidadeVidas = new List<RelatorioCidadeVidas> 
            {
                new RelatorioCidadeVidas 
                { 
                    Cidade = "Rio de Janeiro",
                    Quantidade = Vida.Count(x => (x.EnderecoResidencial != null && x.EnderecoResidencial.Contains("Rio de Janeiro")) || (x.EnderecoComercial != null && x.EnderecoComercial.Contains("Rio de Janeiro")))
                },
                new RelatorioCidadeVidas 
                { 
                    Cidade = "São Paulo",
                    Quantidade = Vida.Count(x => (x.EnderecoResidencial != null && x.EnderecoResidencial.Contains("São Paulo")) || (x.EnderecoComercial != null && x.EnderecoComercial.Contains("São Paulo")))
                },
                new RelatorioCidadeVidas
                {
                    Cidade = "Minas Gerais",
                    Quantidade = Vida.Count(x => (x.EnderecoResidencial != null && x.EnderecoResidencial.Contains("São Paulo")) || (x.EnderecoComercial != null && x.EnderecoComercial.Contains("Minas Gerais")))
                }
            };

            return Page();
        }
    }
}