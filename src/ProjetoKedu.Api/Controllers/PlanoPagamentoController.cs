using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using System.Numerics;

namespace ProjetoKedu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoPagamentoController : ControllerBase
    {
        private readonly IPlanoPagamentoService _service;
        public PlanoPagamentoController(IPlanoPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPlano(PlanoPagamentoDto planoPagamento)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _service.CadastrarPlanoPagamento(planoPagamento);

            if (id != Guid.Empty)
            {
                var plano = await _service.RetornaPlanoPorId(id);

                return Ok(new RetornoPadraoDto<PlanoPagamentoDto>
                {
                    StatusCode = 200,
                    Mensagem = "Plano encontrado.",
                    Retorno = new List<PlanoPagamentoDto> { plano }
                }); 
            }

            return BadRequest(new RetornoPadraoDto<string>
            {
                StatusCode = 400,
                Mensagem = "Nenhun plano registrado.",
                Retorno = null
            });

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> RetornaPlanoPorId(Guid id)
        {
            var plano = await _service.RetornaPlanoPorId(id);

            if (plano is null)
                return BadRequest(new RetornoPadraoDto<string>
                {
                    StatusCode = 400,
                    Mensagem = "Nenhun plano encontrado.",
                    Retorno = null
                });

            return Ok(new RetornoPadraoDto<PlanoPagamentoDto>
            {
                StatusCode = 200,
                Mensagem = "Plano encontrado.",
                Retorno = new List<PlanoPagamentoDto> { plano } 
            });
        }

        [HttpGet]
        public async Task<IActionResult> RetornaPlanos()
        {
            var planos = await _service.RetornaPlanos();

            if (planos?.Count() < 1)
                return BadRequest(new RetornoPadraoDto<string>
                {
                    StatusCode = 400,
                    Mensagem = "Nenhun plano encontrado.",
                    Retorno = null
                });

            return Ok(new RetornoPadraoDto<PlanoPagamentoDto>
            {
                StatusCode = 200,
                Mensagem = "Plano encontrado.",
                Retorno = planos
            });
        }
        
        [HttpGet("{id:guid}/total")]
        public async Task<IActionResult> RetornaTotalPlano(Guid id)
        {
            var plano = await _service.RetornaPlanoPorId(id);

            if (plano is null)
                return BadRequest(new RetornoPadraoDto<string>
                {
                    StatusCode = 400,
                    Mensagem = "Nenhun plano encontrado.",
                    Retorno = null
                });

            return Ok(new RetornoPadraoDto<decimal>
            {
                StatusCode = 200,
                Mensagem = "Plano encontrado.",
                Retorno = new List<decimal> { plano.ValorTotalPlano }
            });
        }
    }
}
