using Xunit;
using TaskManager.Controllers;
using TaskManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Tests
{
    public class NotificacaoControllerTests
    {
        [Fact]
        public void Deve_Criar_Notificacao_Valida()
        {
            var controller = new NotificacaoController();
            var notificacao = new Notificacao { Titulo = "Nova tarefa", Mensagem = "Você recebeu uma nova tarefa." };
            var resultado = controller.Criar(notificacao);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_BadRequest_Notificacao_Invalida()
        {
            var controller = new NotificacaoController();
            var notificacao = new Notificacao { Titulo = "", Mensagem = "" };
            var resultado = controller.Criar(notificacao);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Marcar_Notificacao_Como_Lida()
        {
            var controller = new NotificacaoController();
            var notificacao = new Notificacao { Titulo = "Nova tarefa", Mensagem = "Você recebeu uma nova tarefa." };
            var resultado = controller.MarcarComoLida(notificacao);
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
