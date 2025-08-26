using System;
using System.Collections.Generic;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Usuario : EntidadeBase
    {
        public int Id { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
        public UserRole Perfil { get; set; }
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
