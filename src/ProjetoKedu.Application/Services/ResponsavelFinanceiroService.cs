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
            var responsaveis = await _repository.Consultar();
          
            var responsavelDto = new List<ResponsavelFinanceiroDto>();

            foreach (var responsavel in responsaveis)
            {
                responsavelDto.Add(new ResponsavelFinanceiroDto(responsavel.Id, responsavel.Nome));
            }

            return responsavelDto;

        }

        public async Task<ResponsavelFinanceiroDto> ConsultarPorId(Guid id)
        {
            var responsavelFinanceiro = await _repository.ConsultarPorId(id);

            return new ResponsavelFinanceiroDto(responsavelFinanceiro.Id, responsavelFinanceiro.Nome);
        }

        public Task<ResponsavelFinanceiroDto> EditarResponsavel(Guid id, ResponsavelFinanceiroDto responsavelFinanceiroDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverResponsavel(Guid id)
        {
            var removido = _repository.Remover(id);
            return removido;
        }

        // implementar o metodo da inteface - editar
        // receber o id
        // consultar por id o responsavel
        // alterar o nome do responsavel com o nome enviado via request body
    }
}
