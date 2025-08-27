using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Usuario : EntidadeBase
    {
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        [MaxLength(255)]
        public string? PrimeiroNome { get; set; }
        [MaxLength(255)]
        public string? UltimoNome { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(255)]
        public string? SenhaHash { get; set; }
        public UserRole Perfil { get; set; }
        [MaxLength(255)]
        public string? UrlImagemPerfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime? UltimoLogin { get; set; }

        public string NomeCompleto => $"{PrimeiroNome} {UltimoNome}";

        public virtual ICollection<ProjetoUsuario>? ProjetosUsuarios { get; set; }
        public virtual ICollection<Tarefa>? TarefasAtribuidas { get; set; }
        public virtual ICollection<Tarefa>? TarefasCriadas { get; set; }
        public virtual ICollection<Projeto>? ProjetosCriados { get; set; }
        public virtual ICollection<Notificacao>? Notificacoes { get; set; }
    }
}
