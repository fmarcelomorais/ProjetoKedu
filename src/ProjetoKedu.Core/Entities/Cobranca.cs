using ProjetoKedu.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class Cobranca : Entity
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public EMetodoPagamento MetodoPagamento { get; set; }
        public EStatusCobranca StatusCobranca { get; set; }
        public string CodigoPagamento { get; set; }       

        public Cobranca(int numero, decimal valor, DateTime dataVencimento, EMetodoPagamento metodoPagamento, EStatusCobranca statusCobranca)
        {
            Numero = numero;
            Valor = valor;
            Vencimento = dataVencimento;
            MetodoPagamento = metodoPagamento;
            StatusCobranca = statusCobranca;
            CodigoPagamento = CriaCodigoPagamento();
        }

        public Cobranca()
        {

        }
        private string CriaCodigoPagamento()
        {
            if (MetodoPagamento == EMetodoPagamento.BOLETO)
                return "74891.12021 34567.890004 12345.678901 1 23450000010000";
            if (MetodoPagamento == EMetodoPagamento.PIX)
                return "00020126360014BR.GOV.BCB.PIX0114fa1e2d3c4b5a6d7f8g9h520400005303986540510.005802BR5920NOME FICTICIO TESTE6009CURITIBA62070503***6304ABCD";
            return "";
        }
    }
}
