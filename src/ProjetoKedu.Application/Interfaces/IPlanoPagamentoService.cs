using ProjetoKedu.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Interfaces
{
    public interface IPlanoPagamentoService
    {
        Task<Guid> CadastrarPlanoPagamento(PlanoPagamentoDto planoPagamentoDto);
        Task<PlanoPagamentoDto> RetornaPlanoPorId(Guid id);
        Task<IEnumerable<PlanoPagamentoDto>> RetornaPlanos();
    }
}
