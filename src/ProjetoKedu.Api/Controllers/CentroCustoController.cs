using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;

namespace ProjetoKedu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroCustoController : ControllerBase
    {
        private readonly ICentroCustoService _service;
        public CentroCustoController(ICentroCustoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(CentroDeCustoDto centroDeCusto)
        {
            var cadastrado = await _service.SalvarCentroDeCusto(centroDeCusto);

            if (!cadastrado)
                return BadRequest(new RetornoPadraoDto<string>()
                {
                    StatusCode = 400,
                    Mensagem = "Erro ao cadastrar Centro de Custo",
                });

            return Ok(new RetornoPadraoDto<CentroDeCustoDto>
            {
                StatusCode = 201,
                Mensagem = "Centro de Custo Cadastrado Com sucesso",                
            });
        }

        [HttpGet]
        public async Task<IActionResult> RetornaCentroDeCusto()
        {
            var centroDeCusto = await _service.RetornaCentroDeCusto();
            return Ok(new RetornoPadraoDto<CentroDeCustoDto>
            {
                StatusCode = 200,
                Mensagem = "Sucesso",
                Retorno = centroDeCusto
            });
        }

        [HttpGet("{codigo:int}")]
        public async Task<IActionResult> RetornaCentroDeCustoPorCodigo(int codigo)
        {
            var centroDeCusto = await _service.RetornaCentroDeCustoPorCodigo(codigo);
            return Ok(new RetornoPadraoDto<CentroDeCustoDto>
            {
                StatusCode = 200,
                Mensagem = "Sucesso",
                Retorno = new List<CentroDeCustoDto> { centroDeCusto }
            });
        }
    }
}
