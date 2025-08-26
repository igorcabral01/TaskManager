using Xunit;
using TaskManager.Controllers;
using TaskManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Tests
{
    public class TarefaControllerTests
    {
        [Fact]
        public void Deve_Criar_Tarefa_Valida()
        {
            var controller = new TarefaController();
            var tarefa = new Tarefa { Titulo = "Tarefa Teste", Descricao = "Descrição" };
            var resultado = controller.Criar(tarefa);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_BadRequest_Tarefa_Invalida()
        {
            var controller = new TarefaController();
            var tarefa = new Tarefa { Titulo = "", Descricao = "" };
            var resultado = controller.Criar(tarefa);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Atualizar_Tarefa_Valida()
        {
            var controller = new TarefaController();
            var tarefa = new Tarefa { Titulo = "Tarefa Teste", Descricao = "Descrição" };
            var resultado = controller.Atualizar(tarefa);
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
