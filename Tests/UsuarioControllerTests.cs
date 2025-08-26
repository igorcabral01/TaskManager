using Xunit;
using TaskManager.Controllers;
using TaskManager.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace TaskManager.Tests
{
    public class UsuarioControllerTests
    {
        [Fact]
        public void Deve_Criar_Usuario_Valido()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TaskManager.Mappings.UsuarioProfile())).CreateMapper();
            var controller = new UsuarioController(mapper);
            var dto = new CreateUsuarioDto { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", Senha = "123456", Perfil = "User" };
            var resultado = controller.Criar(dto);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_BadRequest_Usuario_Invalido()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TaskManager.Mappings.UsuarioProfile())).CreateMapper();
            var controller = new UsuarioController(mapper);
            var dto = new CreateUsuarioDto { PrimeiroNome = "", UltimoNome = "", Email = "", Senha = "", Perfil = "User" };
            var resultado = controller.Criar(dto);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Atualizar_Usuario_Valido()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TaskManager.Mappings.UsuarioProfile())).CreateMapper();
            var controller = new UsuarioController(mapper);
            var dto = new UpdateUsuarioDto { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", Perfil = "User" };
            var resultado = controller.Atualizar(dto);
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
