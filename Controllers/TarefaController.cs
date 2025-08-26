using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _tarefaService;
        private readonly TarefaValidator _validator;

        public TarefaController()
        {
            _tarefaService = new TarefaService();
            _validator = new TarefaValidator();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Tarefa tarefa)
        {
            var validacao = _validator.Validate(tarefa);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novaTarefa = _tarefaService.CriarTarefa(tarefa);
            return Ok(novaTarefa);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Tarefa tarefa)
        {
            var validacao = _validator.Validate(tarefa);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var tarefaAtualizada = _tarefaService.AtualizarTarefa(tarefa);
            return Ok(tarefaAtualizada);
        }
    }
}
