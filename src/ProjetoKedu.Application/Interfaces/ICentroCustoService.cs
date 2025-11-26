using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Interfaces
{
    public interface ICentroCustoService
    {
        Task<bool> SalvarCentroDeCusto(CentroDeCustoDto centroDeCusto);
        Task<IEnumerable<CentroDeCustoDto>> RetornaCentroDeCusto();
        Task<CentroDeCustoDto> RetornaCentroDeCustoPorCodigo(int codigo);
    }
}
