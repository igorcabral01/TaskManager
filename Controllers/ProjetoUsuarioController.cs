using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;

using Microsoft.AspNetCore.Authorization;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProjetoUsuarioController : ControllerBase
    {
        private readonly ProjetoUsuarioService _service;

        public ProjetoUsuarioController(ProjetoUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProjetoUsuario projetoUsuario)
        {
            var novoRelacionamento = await _service.AdicionarUsuarioAoProjetoAsync(projetoUsuario);
            return Ok(novoRelacionamento);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProjetoUsuario projetoUsuario)
        {
            await _service.AtualizarAsync(id, projetoUsuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _service.DeletarAsync(id);
            return Ok();
        }
    }
}
