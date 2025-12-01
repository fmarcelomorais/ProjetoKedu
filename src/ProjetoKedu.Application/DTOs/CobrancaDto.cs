using ProjetoKedu.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.DTOs
{
    public record CobrancaDto(Guid? Id, int Numero, decimal Valor, DateTime DataVencimento, EMetodoPagamento MetodoPagamento, EStatusCobranca StatusCobranca, string CodigoPagamento = "");
    public record CobrancaResponsavelDto(string Nome, List<CobrancaDto> Cobrancas);
}
