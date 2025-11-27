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
        public async Task<bool> SalvarResponsavel(ResponsavelFinanceiroDto responsavelFinanceiroDto)
        {
            var responsavel = new ResponsavelFinanceiro(responsavelFinanceiroDto.Nome);

            var cadastrado = await _repository.Cadastrar(responsavel);

            if (cadastrado)
                return true;
            return false;
        }

        public async Task<IEnumerable<ResponsavelFinanceiroDto>> ConsultarTodosResponsaveis()
        {

            var responsaveis = await _repository.Consultar<ResponsavelFinanceiro>();

            var responsavelDto = new List<ResponsavelFinanceiroDto>();

            foreach (var consultar in responsaveis)
            {
                responsavelDto.Add(new ResponsavelFinanceiroDto(consultar.NomeResponsavel()));
            }

            return responsavelDto;

        }

        public async Task<ResponsavelFinanceiroDto> ConsultarPorId(Guid id)
        {
            var responsavelFinanceiro = await _repository.ConsultarPorId<ResponsavelFinanceiro>(id);

            return new ResponsavelFinanceiroDto(responsavelFinanceiro.NomeResponsavel());
        }
    }
}
