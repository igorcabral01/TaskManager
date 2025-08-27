using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Task;
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
        private readonly IMapper _mapper;

        public TarefaController(IMapper mapper, TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            _validator = new TarefaValidator();
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TarefaDto tarefa)
        {
            var tarefas = _mapper.Map<Tarefa>(tarefa);
            var validacao = _validator.Validate(tarefas);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novaTarefa = _tarefaService.CriarTarefaAsync(tarefas);
            return Ok(novaTarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] TarefaDto tarefa)
        {
            var tarefas = _mapper.Map<Tarefa>(tarefa);
            var validacao = _validator.Validate(tarefas);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var tarefaAtualizada = _tarefaService.AtualizarTarefaAsync(id,tarefas);
            return Ok(tarefaAtualizada);
        }
    }
}
