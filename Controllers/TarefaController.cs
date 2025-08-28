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
        public async Task<IActionResult> Criar([FromBody] TarefaDto tarefa)
        {
            var entidade = _mapper.Map<Tarefa>(tarefa);
            var validacao = _validator.Validate(entidade);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novaTarefa = await _tarefaService.CriarTarefaAsync(entidade);
            var tarefaDto = _mapper.Map<TarefaDto>(novaTarefa);
            return Ok(tarefaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TarefaDto tarefa)
        {
            var entidade = _mapper.Map<Tarefa>(tarefa);
            var validacao = _validator.Validate(entidade);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            await _tarefaService.AtualizarTarefaAsync(id, entidade);
            return Ok();
        }
    }
}
