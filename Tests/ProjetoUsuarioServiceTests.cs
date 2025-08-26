using Xunit;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Tests
{
    public class ProjetoUsuarioServiceTests
    {
        [Fact]
        public void Deve_Adicionar_Usuario_Projeto_Com_DataEntrada()
        {
            var service = new ProjetoUsuarioService();
            var projetoUsuario = new ProjetoUsuario { ProjetoId = Guid.NewGuid(), UsuarioId = Guid.NewGuid() };
            var resultado = service.AdicionarUsuarioAoProjeto(projetoUsuario);
            Assert.True(resultado.DataEntrada <= System.DateTime.Now);
        }
    }
}
