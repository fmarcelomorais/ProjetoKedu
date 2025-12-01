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
    public class CentroDeCustoService : ICentroCustoService
    {
        private readonly ICentroDeCustoRep _repository;
        public CentroDeCustoService(ICentroDeCustoRep repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CentroDeCustoDto>> RetornaCentroDeCusto()
        {
            var centrosDeCusto = await _repository.RetornaCentroDeCusto();

            var centrosDeCustoDto = new List<CentroDeCustoDto>();

            foreach(var centro in centrosDeCusto)
            {
                centrosDeCustoDto.Add(new CentroDeCustoDto(centro.Id, centro.Codigo, centro.Tipo));
            }

            return centrosDeCustoDto;
        }

        public async Task<CentroDeCustoDto> RetornaCentroDeCustoPorCodigo(int codigo)
        {
            var centroDeCusto = await _repository.RetornaCentroDeCustoPorCodigo(codigo);

            return new CentroDeCustoDto(centroDeCusto.Id, centroDeCusto.Codigo, centroDeCusto.Tipo);
        }

        public async Task<bool> SalvarCentroDeCusto(CentroDeCustoDto centroDeCustoDto)
        {
            var centroDeCusto = new CentroDeCusto(centroDeCustoDto.Id, centroDeCustoDto.Codigo, centroDeCustoDto.Tipo);

            var cadastrado = await _repository.Cadastrar(centroDeCusto);

            if (cadastrado)
                return true;
            return false;
        }
    }
}
