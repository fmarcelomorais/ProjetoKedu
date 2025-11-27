using ProjetoKedu.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Interfaces
{
    public interface IResponsavelFinanceiroService
    {
        Task<bool> SalvarResponsavel(ResponsavelFinanceiroDto responsavelFinanceiroDto);

        Task<IEnumerable<ResponsavelFinanceiroDto>> ConsultarTodosResponsaveis();

        Task<ResponsavelFinanceiroDto> ConsultarPorId(Guid id);

        // Criar assinatura de editar


    }
}
