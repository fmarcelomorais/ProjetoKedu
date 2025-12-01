using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Interfaces
{
    public interface ICobrancaRep
    {
        Task<Cobranca> RegistrarPagamento(RegistroPagamento registroPagamento);
    }
}
