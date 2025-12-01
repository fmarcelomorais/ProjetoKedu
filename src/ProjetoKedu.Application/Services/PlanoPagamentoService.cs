using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Services
{
    public class PlanoPagamentoService : IPlanoPagamentoService
    {
        private readonly IPlanoPagamentoRep _planoPagamentoRep;
        public PlanoPagamentoService(IPlanoPagamentoRep planoPagamentoRep)
        {
            _planoPagamentoRep = planoPagamentoRep;
        }
        public async Task<Guid> CadastrarPlanoPagamento(PlanoPagamentoDto planoPagamentoDto)
        {
            var responsavel = new ResponsavelFinanceiro(planoPagamentoDto.Responsavel.Id, planoPagamentoDto.Responsavel.Nome);
            var centroCusto = new CentroDeCusto(planoPagamentoDto.centroDeCusto.Id, planoPagamentoDto.centroDeCusto.Codigo, planoPagamentoDto.centroDeCusto.Tipo);
            var cobrancas = new List<Cobranca>();
            foreach (var cobranca in planoPagamentoDto.Cobrancas)
                cobrancas.Add(new Cobranca(cobranca.Numero, cobranca.Valor, cobranca.DataVencimento, cobranca.MetodoPagamento, cobranca.StatusCobranca));

            var planoPagamento = new PlanoDePagamento(responsavel, centroCusto, cobrancas);

            var id = await _planoPagamentoRep.CadastrarPlano(planoPagamento);

            return id;
        }

        public async Task<PlanoPagamentoDto> RetornaPlanoPorId(Guid id)
        {
            var planoPagamento = await _planoPagamentoRep.ConsultarPlanoPorId(id);
            var responsavel = planoPagamento.Responsavel;
            var centroCusto = planoPagamento.CentroCusto;

            var responsavelDto = new ResponsavelFinanceiroDto(responsavel.Id, responsavel.Nome);
            var centroCustoDto = new CentroDeCustoDto(centroCusto.Id, centroCusto.Codigo, centroCusto.Tipo);

            var cobrancasDto = new List<CobrancaDto>();
            foreach(var cobranca in planoPagamento.Cobrancas)
            {
                cobrancasDto.Add(new CobrancaDto(cobranca.Id, cobranca.Numero, cobranca.Valor, cobranca.Vencimento, cobranca.MetodoPagamento, cobranca.StatusCobranca, cobranca.CodigoPagamento));
            }

            var plano = new PlanoPagamentoDto(planoPagamento.Id, responsavelDto, centroCustoDto, cobrancasDto, planoPagamento.ValorTotalPlano);

            return plano;
        }

        public async Task<IEnumerable<PlanoPagamentoDto>> RetornaPlanos()
        {
            var planosPagamentos = await _planoPagamentoRep.ConsultarPlanos();
            var planosPagamentoDto = new List<PlanoPagamentoDto>();

            foreach(var plano in planosPagamentos)
            {
                var responsavel = new ResponsavelFinanceiroDto(plano.Responsavel.Id, plano.Responsavel.Nome);
                var centroCusto = new CentroDeCustoDto(plano.CentroCusto.Id, plano.CentroCusto.Codigo, plano.CentroCusto.Tipo);
                var cobrancas = new List<CobrancaDto>();
                foreach (var cobranca in plano.Cobrancas)
                {
                    if(!cobrancas.Any(c => c.Id == cobranca.Id))
                        cobrancas.Add(new CobrancaDto(cobranca.Id, cobranca.Numero, cobranca.Valor, cobranca.Vencimento, cobranca.MetodoPagamento, cobranca.StatusCobranca, cobranca.CodigoPagamento));
                }

                if (!planosPagamentoDto.Any(p => p.Id == plano.Id))
                    planosPagamentoDto.Add(new PlanoPagamentoDto(plano.Id, responsavel, centroCusto, cobrancas, cobrancas.Sum(p => p.Valor)));
            }

            return planosPagamentoDto;
        }
    }
}
