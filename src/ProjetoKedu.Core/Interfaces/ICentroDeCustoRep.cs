using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Interfaces
{
    public interface ICentroDeCustoRep
    {
        Task<bool> Cadastrar(CentroDeCusto centroDeCusto);
        Task<IEnumerable<CentroDeCusto>> RetornaCentroDeCusto();
        Task<CentroDeCusto> RetornaCentroDeCustoPorCodigo(int codigo);
    }
}
