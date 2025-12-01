using ProjetoKedu.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class RegistroPagamento : Entity
    {
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; } = DateTime.Now;
        public EStatusCobranca Status { get; set; } = EStatusCobranca.PAGA;
        public Guid IdCobranca { get; set; }

        public RegistroPagamento(Guid id, decimal valor, DateTime dataPagamento)
        {
            Valor = valor;
            DataPagamento = dataPagamento;
            IdCobranca = id;
        }
        public RegistroPagamento() { }
    }
}
