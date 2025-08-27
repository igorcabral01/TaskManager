using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Project;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoService _projetoService;
        private readonly ProjetoValidator _validator;
        private readonly IMapper _mapper;

        public ProjetoController(ProjetoService projetoService, ProjetoValidator validator, IMapper mapper)
        {
            _projetoService = projetoService;
            _validator = validator;
            _mapper = mapper;  
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var projetos = await _projetoService.ObterTodosProjetosAsync();
            return Ok(projetos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {

            var projeto = await _projetoService.ObterProjetoPorIdAsync(id);
            if (projeto == null)
                return NotFound("Projeto não encontrado.");
            return Ok(projeto);
        }

        [HttpPost]
       // [Authorize]
        public async Task<IActionResult> Criar([FromBody] ProjetoDto projeto)
        {
            var novoProjeto = _mapper.Map<Projeto>(projeto);
            var validacao = _validator.Validate(novoProjeto);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);
            
            await _projetoService.CriarProjetoAsync(novoProjeto);
            return Ok(novoProjeto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProjetoDto projeto)
        {
            var novoProjeto = _mapper.Map<Projeto>(projeto);
            var validacao = _validator.Validate(novoProjeto);

            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);
            await _projetoService.AtualizarProjetoAsync(id,novoProjeto);

            return Ok(novoProjeto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var projeto = await _projetoService.ObterProjetoPorIdAsync(id);

            if (projeto == null)
                return NotFound("Projeto não encontrado.");
            await _projetoService.DeletarProjetoAsync(id);

            return NoContent();
        }
    }
}
