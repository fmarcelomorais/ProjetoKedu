using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.DTOs
{
    public record PlanosPagamentoResponsavelDTO(string nome, int quantidade, List<DadosPlanos> dados);
    public record DadosPlanos(string centroCusto, int quantidadeCobranca, decimal valorTotal);
}
