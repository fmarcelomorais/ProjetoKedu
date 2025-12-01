using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;

namespace ProjetoKedu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {
        private readonly ICobrancaService _service; 
        public CobrancaController(ICobrancaService service)
        {
            _service = service;
        }

        [HttpPost("{id:guid}/pagamento")]
        public async Task<IActionResult> RegistrarPagamento(Guid id, RegistoPagamentoDto registroPagamento)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new RetornoPadraoDto<RegistoPagamentoDto>(){
                    StatusCode = 400,
                    Mensagem = "Todos os dados precisam ser informados.",
                    Retorno = new List<RegistoPagamentoDto> { registroPagamento }
                });

            var registro = await _service.RegistraCobranca(id, registroPagamento);

            if(registro is null)
                return BadRequest(new RetornoPadraoDto<RegistoPagamentoDto>()
                {
                    StatusCode = 400,
                    Mensagem = "Não foi possivel Registrar o pagamento.",
                    Retorno = new List<RegistoPagamentoDto> { registroPagamento }
                });

            return Ok(new RetornoPadraoDto<CobrancaDto>()
            {
                StatusCode = 200,
                Mensagem = "Registrado com sucesso.",
                Retorno = new List<CobrancaDto> { registro }
            });
        }
        
    }
}
