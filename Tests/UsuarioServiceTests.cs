// using Xunit;
// using TaskManager.Models;
// using TaskManager.Services;

// namespace TaskManager.Tests
// {
//     public class UsuarioServiceTests
//     {
//         [Fact]
//         public void Deve_Criar_Usuario_Ativo()
//         {
//             var service = new UsuarioService();
//             var usuario = new Usuario { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", SenhaHash = "123456" };
//             var resultado = service.CriarUsuario(usuario);
//             Assert.True(resultado.Ativo);
//             Assert.Null(resultado.UltimoLogin);
//         }

//         [Fact]
//         public void Deve_Atualizar_DataAtualizacao()
//         {
//             var service = new UsuarioService();
//             var usuario = new Usuario { PrimeiroNome = "João", UltimoNome = "Silva", Email = "joao@teste.com", SenhaHash = "123456" };
//             var resultado = service.AtualizarUsuario(usuario);
//             Assert.True(resultado.DataAtualizacao <= System.DateTime.Now);
//         }
//     }
// }
