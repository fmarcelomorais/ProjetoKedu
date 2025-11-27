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
        Task<ResponsavelFinanceiro> ConsultarPorId<T>(Guid id);
        Task<IEnumerable<ResponsavelFinanceiro>> Consultar<T>();
        Task<ResponsavelFinanceiro> EditarPlano(ResponsavelFinanceiro responsavel);
    }
}
