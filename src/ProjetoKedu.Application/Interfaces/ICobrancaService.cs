using ProjetoKedu.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Interfaces
{
    public interface ICobrancaService
    {
        Task<CobrancaDto> RegistraCobranca(Guid id, RegistoPagamentoDto registoPagamento);
    }
}
