using ProjetoKedu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class PlanoDePagamento : Entity, IPlanoPagamento
    {
        private ResponsavelFinanceiro Responsavel {  get; set; }
        private CentroDeCusto CentroCusto { get; set; }
        private List<Cobranca> Cobrancas { get; set; } = new List<Cobranca>();
        private decimal ValorTotalPlano { get; set; }

        public PlanoDePagamento(ResponsavelFinanceiro responsavelFinanceiro, CentroDeCusto centroDeCusto, List<Cobranca> combrancas)
        {
            Responsavel = responsavelFinanceiro;
            CentroCusto = centroDeCusto;
            ValorTotalPlano = Cobrancas.Sum(c => c.RetornaValor());
        }

        public void CadastrarPlano()
        {

        }

        public PlanoDePagamento ConsultarPlano()
        {
            return this;
        }

        public void EditarPlano(PlanoDePagamento planoDePagamento)
        {
            throw new NotImplementedException();
        }

        
    }
}
