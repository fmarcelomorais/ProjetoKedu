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
    }
}
