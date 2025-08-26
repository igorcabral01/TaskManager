using Microsoft.AspNetCore.Mvc;
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

        public NotificacaoController()
        {
            _service = new NotificacaoService();
            _validator = new NotificacaoValidator();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Notificacao notificacao)
        {
            var validacao = _validator.Validate(notificacao);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novaNotificacao = _service.CriarNotificacao(notificacao);
            return Ok(novaNotificacao);
        }

        [HttpPut("marcar-lida")]
        public IActionResult MarcarComoLida([FromBody] Notificacao notificacao)
        {
            var notificacaoLida = _service.MarcarComoLida(notificacao);
            return Ok(notificacaoLida);
        }
    }
}
