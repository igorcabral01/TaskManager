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

        public ProjetoUsuarioController()
        {
            _service = new ProjetoUsuarioService();
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ProjetoUsuario projetoUsuario)
        {
            var novoRelacionamento = _service.AdicionarUsuarioAoProjeto(projetoUsuario);
            return Ok(novoRelacionamento);
        }
    }
}
