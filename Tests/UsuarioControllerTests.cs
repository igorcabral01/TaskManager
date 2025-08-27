using Xunit;
using TaskManager.Controllers;
using TaskManager.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Moq;
using TaskManager.Services;
using TaskManager.Validations;

namespace TaskManager.Tests
{
    public class UsuarioControllerTests
    {
        private UsuarioController GetController()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TaskManager.Mappings.UsuarioProfile())).CreateMapper();
            var usuarioServiceMock = new Mock<UsuarioService>(null);
            var validatorMock = new Mock<UsuarioValidator>();
            validatorMock.Setup(v => v.Validate(It.IsAny<TaskManager.Models.Usuario>())).Returns(new FluentValidation.Results.ValidationResult());
            return new UsuarioController(usuarioServiceMock.Object, validatorMock.Object, mapper);
        }

        [Fact]
        public void Deve_Criar_Usuario_Valido()
        {
            var controller = GetController();
            var dto = new UsuarioDto { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", Senha = "123456", Perfil = "User" };
            var resultado = controller.Criar(dto).Result;
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_BadRequest_Usuario_Invalido()
        {
            var controller = GetController();
            var dto = new UsuarioDto { PrimeiroNome = "", UltimoNome = "", Email = "", Perfil = "User" };
            var resultado = controller.Criar(dto).Result;
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Atualizar_Usuario_Valido()
        {
            var controller = GetController();
            var dto = new UsuarioDto { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", Perfil = "User" };
            var resultado = controller.Atualizar(1, dto).Result;
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
