using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;
using TaskManager.Application.DTOs.User;
using AutoMapper;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly UsuarioValidator _validator;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService usuarioService, UsuarioValidator validator, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var usuarios = await _usuarioService.ObterTodosAsync();
            var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound();
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var validacao = _validator.Validate(usuario);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novoUsuario = await _usuarioService.CriarAsync(usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(novoUsuario);
            return Ok(usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var validacao = _validator.Validate(usuario);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var usuarioAtualizado = await _usuarioService.AtualizarAsync(id, usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuarioAtualizado);
            return Ok(usuarioDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _usuarioService.DeletarAsync(id);
            return NoContent();
        }
    }
}
