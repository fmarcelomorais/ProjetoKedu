using ProjetoKedu.Core.Entities;

namespace ProjetoKedu.Core.Interfaces
{
    public interface IResponsavelFinanceiroRep 
    {
        Task<bool> Cadastrar(ResponsavelFinanceiro responsavel); 
        // Regras
        Task<IEnumerable<PlanoDePagamento>> RetornaPlanos(Guid id);
   
    }
}
