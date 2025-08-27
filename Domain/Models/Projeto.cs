
namespace TaskManager.Models
{
    public class Projeto : EntidadeBase
    {
        public Guid ProjetoId { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid UsuarioId { get; set; }
        public string? Cor { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<ProjetoUsuario>? ProjetosUsuarios { get; set; }
        public virtual ICollection<Tarefa>? Tarefas { get; set; }
    }
}
