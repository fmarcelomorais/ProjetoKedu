using ProjetoKedu.Core.Interfaces;

namespace ProjetoKedu.Core.Entities
{
    public class PlanoDePagamento : Entity
    {
        public ResponsavelFinanceiro Responsavel {  get; set; }
        public CentroDeCusto CentroCusto { get; set; }
        public List<Cobranca> Cobrancas { get; set; } = new List<Cobranca>();
        public decimal ValorTotalPlano { get; set; }

        public PlanoDePagamento(ResponsavelFinanceiro responsavelFinanceiro, CentroDeCusto centroDeCusto, List<Cobranca> combrancas)
        {
            Responsavel = responsavelFinanceiro;
            CentroCusto = centroDeCusto;
            ValorTotalPlano = Cobrancas.Sum(c => c.Valor);
            Cobrancas = combrancas;
        }
        public PlanoDePagamento()
        {
                
        }
        
    }
}
