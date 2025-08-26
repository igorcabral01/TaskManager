using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;
using TaskManager.Application.DTOs.User;
using AutoMapper;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
    private readonly UsuarioService _usuarioService;
    private readonly UsuarioValidator _validator;
    private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper)
        {
            _usuarioService = new UsuarioService();
            _validator = new UsuarioValidator();
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var validacao = _validator.Validate(usuario);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var novoUsuario = _usuarioService.CriarUsuario(usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(novoUsuario);
            return Ok(usuarioDto);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] UpdateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var validacao = _validator.Validate(usuario);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            var usuarioAtualizado = _usuarioService.AtualizarUsuario(usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuarioAtualizado);
            return Ok(usuarioDto);
        }
    }
}
