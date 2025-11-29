using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> RetornarTodosResponsaveis()
        {

            var responsaveis = await _service.ConsultarTodosResponsaveis();

            if (responsaveis?.Count() > 0)
                return Ok(new RetornoPadraoDto<ResponsavelFinanceiroDto>
                {
                    StatusCode = 200,
                    Mensagem = "Sucesso",
                    Retorno = responsaveis
                });


            return BadRequest(new RetornoPadraoDto<string>
            {
                StatusCode = 400,
                Mensagem = "Nenhum responsavel foi encontrado.",
                Retorno = null
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarResponsavelPorId(Guid id)
        {
            var responsavel = await _service.ConsultarPorId(id);

            if (responsavel is null)
                return BadRequest(new RetornoPadraoDto<string>
                {
                    StatusCode = 400,
                    Mensagem = "Nenhum responsavel foi encontrado.",
                    Retorno = null
                });

            return Ok(new RetornoPadraoDto<ResponsavelFinanceiroDto>
            {
                StatusCode = 200,
                Mensagem = "Sucesso",
                Retorno = new List<ResponsavelFinanceiroDto>() { responsavel }
            });

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletado = await _service.RemoverResponsavel(id);

            if (!deletado)
                return BadRequest(new RetornoPadraoDto<string>
                {
                    StatusCode = 400,
                    Mensagem = "Erro ao deletar o responsavel.",
                    Retorno = null
                });

            return Ok(new RetornoPadraoDto<string>
                {
                StatusCode = 204,
                Mensagem = "Responsavel deletado com sucesso.",
                Retorno = null
            });
            // [HttpPut("{id}")] criar a rota de Editar (ResponsavelFinanceiroDto responsavel)
            // retorno padrão de sucesso e erro. 
        }
    }
}
