using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Interfaces;

namespace ProjetoKedu.Application.Services
{
    public class ResponsavelFinanceiroService : IResponsavelFinanceiroService
    {
        private readonly IResponsavelFinanceiroRep _repository;
        public ResponsavelFinanceiroService(IResponsavelFinanceiroRep repository)
        {
            _repository = repository;
        }

        public async Task<PlanosPagamentoResponsavelDTO> PlanosPagamento(Guid id)
        {
            var consulta = await _repository.RetornaPlanos(id);            

            var responsavel = consulta.FirstOrDefault().Responsavel.Nome;
            var dados =  new List<DadosPlanos>();

            foreach (var plano in consulta)
                dados.Add(new DadosPlanos(plano.CentroCusto.Tipo, plano.Cobrancas.Count, plano.ValorTotalPlano));

            var planosResponsvavel = new PlanosPagamentoResponsavelDTO(responsavel, consulta.Count(), dados);

            return planosResponsvavel;
        }
        public async Task<CobrancaResponsavelDto> Cobrancas(Guid id)
        {
            var consulta = await _repository.RetornaPlanos(id);
            var listaCobrancas = new List<CobrancaDto>();

            foreach (var cobranca in consulta.FirstOrDefault().Cobrancas)
                listaCobrancas.Add(new CobrancaDto(cobranca.Id, cobranca.Numero, cobranca.Valor, cobranca.Vencimento, cobranca.MetodoPagamento, cobranca.StatusCobranca, cobranca.CodigoPagamento));
            
            var cobrancas = new CobrancaResponsavelDto(consulta.FirstOrDefault().Responsavel.Nome, listaCobrancas);

            return cobrancas;
        }
        public async Task<bool> SalvarResponsavel(ResponsavelFinanceiroDto responsavelFinanceiroDto)
        {
            var responsavel = new ResponsavelFinanceiro(responsavelFinanceiroDto.Id, responsavelFinanceiroDto.Nome);

            var cadastrado = await _repository.Cadastrar(responsavel);

            if (cadastrado)
                return true;
            return false;
        }
    }
}
