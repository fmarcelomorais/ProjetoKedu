using ProjetoKedu.Core.Entities;

namespace ProjetoKedu.Core.Interfaces
{
    public interface IPlanoPagamentoRep
    {
        Task<Guid> CadastrarPlano(PlanoDePagamento planoPagamento);
        Task<IEnumerable<PlanoDePagamento>> ConsultarPlanos();
        Task<PlanoDePagamento> ConsultarPlanoPorId(Guid id);
    }
}
