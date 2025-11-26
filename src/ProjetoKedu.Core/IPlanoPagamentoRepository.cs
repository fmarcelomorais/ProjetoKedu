using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core
{
    public interface IPlanoPagamentoRepository
    {
        Task<PlanoDePagamento> CadastrarPlano(PlanoDePagamento planoDePagamento);
        Task<PlanoDePagamento> ConsultarPlanoPorId(Guid id);
        Task<PlanoDePagamento> EditarPlano(PlanoDePagamento planoDePagamento);
    }
}
