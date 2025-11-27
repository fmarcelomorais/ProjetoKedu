using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Interfaces
{
    public interface IResponsavelFinanceiroRep 
    {
        Task<bool> Cadastrar(ResponsavelFinanceiro responsavel);
        Task<ResponsavelFinanceiro> ConsultarPorId(Guid id);
        Task<IEnumerable<ResponsavelFinanceiro>> Consultar();
        Task<ResponsavelFinanceiro> Editar(ResponsavelFinanceiro responsavel);
    }
}
