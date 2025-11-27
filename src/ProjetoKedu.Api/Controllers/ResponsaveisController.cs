using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;

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
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var cadastrado = await _service.SalvarResponsavel(responsavel);

            if(cadastrado)
                return Created();
            return BadRequest("Erro ao Cadastrar Responsavel");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ResponsavelFinanceiroDto responsavel)
        {
            return Ok();
        }
    }
}
