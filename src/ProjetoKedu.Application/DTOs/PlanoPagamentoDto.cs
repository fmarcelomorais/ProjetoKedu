using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.DTOs
{
    public record PlanoPagamentoDto(Guid? Id, ResponsavelFinanceiroDto Responsavel, CentroDeCustoDto centroDeCusto, List<CobrancaDto> Cobrancas, decimal ValorTotalPlano = 0 );
}
