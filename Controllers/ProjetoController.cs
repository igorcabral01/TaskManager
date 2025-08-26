using Microsoft.AspNetCore.Mvc;
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

        public ProjetoController()
        {
            _projetoService = new ProjetoService();
            _validator = new ProjetoValidator();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            // Exemplo: Retornar lista estática (substitua por consulta ao banco)
            var projetos = new List<Projeto>();
            return Ok(projetos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // Exemplo: Retornar projeto estático (substitua por consulta ao banco)
            Projeto projeto = null;
            if (projeto == null)
                return NotFound("Projeto não encontrado.");
            return Ok(projeto);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Projeto projeto)
        {
            var validacao = _validator.Validate(projeto);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novoProjeto = _projetoService.CriarProjeto(projeto);
            return Ok(novoProjeto);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Projeto projeto)
        {
            var validacao = _validator.Validate(projeto);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var projetoAtualizado = _projetoService.AtualizarProjeto(projeto);
            return Ok(projetoAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            // Exemplo: Excluir projeto estático (substitua por lógica de exclusão)
            bool removido = false;
            if (!removido)
                return NotFound("Projeto não encontrado para exclusão.");
            return NoContent();
        }
    }
}
