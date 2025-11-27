using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class Pagamento
    {
        private decimal Total {  get; set; }
        private DateTime DataPagamento { get; set; }
        private ResponsavelFinanceiro Responsavel {  get; set; }
        public Pagamento()
        {
            
        }
    }
}
