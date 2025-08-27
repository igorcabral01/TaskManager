using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class ProjetoService : Interfaces.IProjetoService
    {
        private readonly AppDbContext _context;

        public ProjetoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Projeto>> ObterTodosProjetosAsync()
        {
            try
            {
                return await _context.Projetos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todos os projetos: " + ex.Message);
            }
        }

        public async Task<Projeto> CriarProjetoAsync(Projeto projeto)
        {
            try
            {
                var projetoExistente = await _context.Projetos
                    .FirstOrDefaultAsync(p => p.Nome == projeto.Nome);

                if (projetoExistente != null)
                {
                    throw new InvalidOperationException("Já existe um projeto com este nome.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar existência do projeto: " + ex.Message);
            }
            await _context.Projetos.AddAsync(projeto);
            await _context.SaveChangesAsync();

            // Envia para outra API via RabbitMQ
            var publisher = new RabbitMqPublisher();
            var json = JsonSerializer.Serialize(projeto);
            await publisher.PublishAsync("projeto-criado", json);

            return projeto;
        }

        public async Task<Projeto?> ObterProjetoPorIdAsync(int id)
        {
            try
            {
                return await _context.Projetos.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter projeto por ID: " + ex.Message);
            }
        }

        public async Task AtualizarProjetoAsync(Guid idProjeto, Projeto projeto)
        {
            try
            {
                var projetoExistente = await _context.Projetos.FindAsync(idProjeto);
                if (projetoExistente == null)
                    throw new Exception("Projeto não encontrado.");
                projetoExistente.Nome = projeto.Nome;
                projetoExistente.Descricao = projeto.Descricao;
                projetoExistente.DataInicio = projeto.DataInicio;
                projetoExistente.DataFim = projeto.DataFim;
                projetoExistente.Ativo = projeto.Ativo;
                projetoExistente.Cor = projeto.Cor;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar projeto: " + ex.Message);
            }
        }

        public async Task DeletarProjetoAsync(int id)
        {
            try
            {
                var projeto = await _context.Projetos.FindAsync(id);
                if (projeto != null)
                {
                    _context.Projetos.Remove(projeto);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar projeto: " + ex.Message);
            }
        }
    }
}

