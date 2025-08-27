using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{

    public class TarefaService : Interfaces.ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> ObterTodasTarefasAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa?> ObterTarefaPorIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            tarefa.Status = Enums.TaskStatus.ToDo;
            tarefa.DataCriacao = DateTime.Now;
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task AtualizarTarefaAsync(Guid id, Tarefa tarefa)
        {
            var tarefaExistente = await _context.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
                throw new Exception("Tarefa não encontrada.");

            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Status = tarefa.Status;
            tarefaExistente.Prioridade = tarefa.Prioridade;
            tarefaExistente.DataVencimento = tarefa.DataVencimento;
            tarefaExistente.DataConclusao = tarefa.DataConclusao;
            tarefaExistente.ProjetoId = tarefa.ProjetoId;
            tarefaExistente.AtribuidaParaId = tarefa.AtribuidaParaId;
            tarefaExistente.CriadaPorId = tarefa.CriadaPorId;
            tarefaExistente.HorasEstimadas = tarefa.HorasEstimadas;
            tarefaExistente.HorasReais = tarefa.HorasReais;
            tarefaExistente.Observacoes = tarefa.Observacoes;

            await _context.SaveChangesAsync();
        }

        public async Task DeletarTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
