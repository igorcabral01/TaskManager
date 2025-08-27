// using Xunit;
// using TaskManager.Models;
// using TaskManager.Services;

// namespace TaskManager.Tests
// {
//     public class ProjetoServiceTests
//     {
//         [Fact]
//         public void Deve_Criar_Projeto_Ativo()
//         {
//             var service = new ProjetoService();
//             var projeto = new Projeto { Nome = "Projeto Teste", Descricao = "Descrição" };
//             var resultado = service.CriarProjeto(projeto);
//             Assert.True(resultado.Ativo);
//             Assert.NotNull(resultado.DataInicio);
//         }

//         [Fact]
//         public void Deve_Atualizar_DataAtualizacao()
//         {
//             var service = new ProjetoService();
//             var projeto = new Projeto { Nome = "Projeto Teste", Descricao = "Descrição" };
//             var resultado = service.AtualizarProjeto(projeto);
//             Assert.True(resultado.DataAtualizacao <= System.DateTime.Now);
//         }
//     }
// }
