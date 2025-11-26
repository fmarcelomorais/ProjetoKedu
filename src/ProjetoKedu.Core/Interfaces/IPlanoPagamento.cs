using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Interfaces
{
    public interface IPlanoPagamento
    {
        void CadastrarPlano();
        PlanoDePagamento ConsultarPlano();
        void EditarPlano(PlanoDePagamento planoDePagamento);
    }
}
