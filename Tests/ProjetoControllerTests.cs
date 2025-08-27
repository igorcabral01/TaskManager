// using Xunit;
// using TaskManager.Controllers;
// using TaskManager.Models;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;

// namespace TaskManager.Tests
// {
//     public class ProjetoControllerTests
//     {
//         [Fact]
//         public void Deve_Listar_Projetos()
//         {
//             var controller = new ProjetoController();
//             var resultado = controller.Listar();
//             Assert.IsType<OkObjectResult>(resultado);
//         }

//         [Fact]
//         public void Deve_Retornar_NotFound_Quando_Projeto_Nao_Existe()
//         {
//             var controller = new ProjetoController();
//             var resultado = controller.BuscarPorId(999);
//             Assert.IsType<NotFoundObjectResult>(resultado);
//         }

//         [Fact]
//         public void Deve_Criar_Projeto_Valido()
//         {
//             var controller = new ProjetoController();
//             var projeto = new Projeto { Nome = "Teste", Descricao = "Projeto de teste" };
//             var resultado = controller.Criar(projeto);
//             Assert.IsType<OkObjectResult>(resultado);
//         }

//         [Fact]
//         public void Deve_Retornar_BadRequest_Quando_Projeto_Invalido()
//         {
//             var controller = new ProjetoController();
//             var projeto = new Projeto { Nome = "", Descricao = "" };
//             var resultado = controller.Criar(projeto);
//             Assert.IsType<BadRequestObjectResult>(resultado);
//         }

//         [Fact]
//         public void Deve_Excluir_Projeto_Nao_Existente()
//         {
//             var controller = new ProjetoController();
//             var resultado = controller.Excluir(999);
//             Assert.IsType<NotFoundObjectResult>(resultado);
//         }
//     }
// }
