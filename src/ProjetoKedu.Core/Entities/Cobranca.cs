using ProjetoKedu.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class Cobranca
    {
        private decimal Valor { get; set; }
        private DateTime DataVencimento { get; set; }
        private EMetodoPagamento MetodoPagamento { get; set; }
        private EStatusCobranca StatusCobranca { get; set; }
        private string CodigoPagamento { get; set; }

        public Cobranca()
        {
            
        }

        public decimal RetornaValor()
            => Valor;
    }
}
