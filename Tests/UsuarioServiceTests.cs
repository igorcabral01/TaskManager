using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Tests
{
    public class UsuarioServiceTests
    {
        private UsuarioService CriarServiceComDb(DbSet<Usuario> dbSet)
        {
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Usuarios).Returns(dbSet);
            return new UsuarioService(mockContext.Object);
        }

        [Fact]
        public async Task CriarAsync_DeveAdicionarUsuario()
        {
            var usuarios = new List<Usuario>();
            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.Setup(m => m.AddAsync(It.IsAny<Usuario>(), default)).Callback<Usuario, System.Threading.CancellationToken>((u, _) => usuarios.Add(u));
            var service = CriarServiceComDb(mockSet.Object);
            var usuario = new Usuario { PrimeiroNome = "Teste", Email = "teste@teste.com" };
            var result = await service.CriarAsync(usuario);
            Assert.Equal("Teste", result.PrimeiroNome);
            Assert.Single(usuarios);
        }

        [Fact]
        public async Task ObterTodosAsync_DeveRetornarLista()
        {
            var data = new List<Usuario> { new Usuario { PrimeiroNome = "A" }, new Usuario { PrimeiroNome = "B" } };
            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var service = CriarServiceComDb(mockSet.Object);
            var result = await service.ObterTodosAsync();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AtualizarAsync_UsuarioNaoEncontrado_DeveLancarExcecao()
        {
            var mockSet = new Mock<DbSet<Usuario>>();
            var service = CriarServiceComDb(mockSet.Object);
            await Assert.ThrowsAsync<Exception>(() => service.AtualizarAsync(99, new Usuario()));
        }
    }
}
