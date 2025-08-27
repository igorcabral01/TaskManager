using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class ProjetoUsuarioService 
    {
        private readonly AppDbContext _context;

        public ProjetoUsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjetoUsuario>> ObterTodosAsync()
        {
            return await _context.ProjetosUsuarios.ToListAsync();
        }

        public async Task<ProjetoUsuario?> ObterPorIdAsync(Guid id)
        {
            return await _context.ProjetosUsuarios.FindAsync(id);
        }

        public async Task<ProjetoUsuario> AdicionarUsuarioAoProjetoAsync(ProjetoUsuario projetoUsuario)
        {
            projetoUsuario.DataEntrada = DateTime.Now;
            await _context.ProjetosUsuarios.AddAsync(projetoUsuario);
            await _context.SaveChangesAsync();

            return projetoUsuario;
        }

        public async Task AtualizarAsync(Guid id, ProjetoUsuario projetoUsuario)
        {
            var existente = await _context.ProjetosUsuarios.FindAsync(id);
            if (existente == null)
                throw new Exception("Relacionamento não encontrado.");

            existente.ProjetoId = projetoUsuario.ProjetoId;
            existente.UsuarioId = projetoUsuario.UsuarioId;
            existente.Proprietario = projetoUsuario.Proprietario;

            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var existente = await ObterPorIdAsync(id);
            if (existente != null)
            {
                _context.ProjetosUsuarios.Remove(existente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
