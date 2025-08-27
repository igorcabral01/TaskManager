using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UsuarioService : Interfaces.IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            usuario.UltimoLogin = null;
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AtualizarAsync(int id, Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null)
                throw new Exception("Usuário não encontrado.");

            existente.PrimeiroNome = usuario.PrimeiroNome;
            existente.UltimoNome = usuario.UltimoNome;
            existente.Email = usuario.Email;
            existente.Perfil = usuario.Perfil;
            existente.UrlImagemPerfil = usuario.UrlImagemPerfil;
            existente.Ativo = usuario.Ativo;
            existente.UltimoLogin = usuario.UltimoLogin;
            existente.DataAtualizacao = DateTime.Now;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task DeletarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
