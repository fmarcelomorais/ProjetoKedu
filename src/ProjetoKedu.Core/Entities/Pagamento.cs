using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class Pagamento
    {
        public decimal Total {  get; set; }
        public DateTime DataPagamento { get; set; }
        public ResponsavelFinanceiro Responsavel {  get; set; }
        public Pagamento()
        {
            
        }
    }
}
