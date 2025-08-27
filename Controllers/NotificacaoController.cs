using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Notificacao;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly NotificacaoService _service;
        private readonly NotificacaoValidator _validator;
        private readonly IMapper _mapper;

        public NotificacaoController(NotificacaoService service, NotificacaoValidator validator, IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] NotificacaoDto notificacao)
        {
            var notificacoes = _mapper.Map<Notificacao>(notificacao);
            var validacao = _validator.Validate(notificacoes);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novaNotificacao = await _service.CriarNotificacaoAsync(notificacoes);
            return Ok(novaNotificacao);
        }

        [HttpPut("marcar-lida/{id}")]
        public async Task<IActionResult> MarcarComoLida(Guid id)
        {
            await _service.MarcarComoLidaAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Notificacao notificacao)
        {
            var validacao = _validator.Validate(notificacao);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            await _service.AtualizarNotificacaoAsync(id, notificacao);
            return Ok();
        }
    }
}
