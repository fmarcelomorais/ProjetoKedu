using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using System.Numerics;

namespace ProjetoKedu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsaveisController : ControllerBase
    {
        private readonly IResponsavelFinanceiroService _service;
        public ResponsaveisController(IResponsavelFinanceiroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ResponsavelFinanceiroDto responsavel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cadastrado = await _service.SalvarResponsavel(responsavel);

            if (cadastrado)
                return Created();
            return BadRequest("Erro ao Cadastrar Responsavel");
        }

        [HttpGet("{id:guid}/planos-de-pagamento")]
        public async Task<IActionResult> RetornaPlanos(Guid id)
        {
            var planos = await _service.PlanosPagamento(id);

            return Ok(new RetornoPadraoDto<PlanosPagamentoResponsavelDTO>
            {
                StatusCode = 200,
                Mensagem = "Planos obtidos com sucesso.",
                Retorno = new List<PlanosPagamentoResponsavelDTO> { planos }
            });
        }

        [HttpGet("{id:guid}/cobrancas")]
        public async Task<IActionResult> RetornaCobrancas(Guid id)
        {
            var cobrancas = await _service.Cobrancas(id);
            return Ok(new RetornoPadraoDto<CobrancaResponsavelDto>
            {
                StatusCode = 200,
                Mensagem = "Planos obtidos com sucesso.",
                Retorno = new List<CobrancaResponsavelDto> { cobrancas }
            });
        }

        [HttpGet("{id:guid}/cobrancas/total")]
        public async Task<IActionResult> RetornaTotalCobrancas(Guid id)
        {
            var cobrancas = await _service.Cobrancas(id);
            return Ok(new RetornoPadraoDto<int>
            {
                StatusCode = 200,
                Mensagem = "Planos obtidos com sucesso.",
                Retorno = new List<int> { cobrancas.Cobrancas.Count() }
            });
        }
    }
}
