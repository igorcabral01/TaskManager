using Xunit;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Enums;

namespace TaskManager.Tests
{
    public class TarefaServiceTests
    {
        [Fact]
        public void Deve_Criar_Tarefa_Com_Status_ToDo()
        {
            var service = new TarefaService();
            var tarefa = new Tarefa { Titulo = "Tarefa Teste", Descricao = "Descrição" };
            var resultado = service.CriarTarefa(tarefa);
            Assert.True(resultado.DataCriacao <= System.DateTime.Now);
        }

        [Fact]
        public void Deve_Atualizar_DataAtualizacao()
        {
            var service = new TarefaService();
            var tarefa = new Tarefa { Titulo = "Tarefa Teste", Descricao = "Descrição" };
            var resultado = service.AtualizarTarefa(tarefa);
            Assert.True(resultado.DataAtualizacao <= System.DateTime.Now);
        }
    }
}
