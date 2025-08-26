using Xunit;
using TaskManager.Controllers;
using TaskManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Tests
{
    public class ProjetoUsuarioControllerTests
    {
        [Fact]
        public void Deve_Adicionar_Usuario_Projeto_Valido()
        {
            var controller = new ProjetoUsuarioController();
            var projetoUsuario = new ProjetoUsuario { ProjetoId = Guid.NewGuid(), UsuarioId = Guid.NewGuid() };
            var resultado = controller.Adicionar(projetoUsuario);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_BadRequest_ProjetoUsuario_Invalido()
        {
            var controller = new ProjetoUsuarioController();
            var projetoUsuario = new ProjetoUsuario { ProjetoId = Guid.Empty, UsuarioId = Guid.Empty };
            var resultado = controller.Adicionar(projetoUsuario);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }
    }
}
