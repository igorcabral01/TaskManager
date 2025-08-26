using System;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class ProjetoUsuario : EntidadeBase
    {
        public Guid ProjetoUsuarioId { get; set; }
        public Guid ProjetoId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataEntrada { get; set; }
        public bool Proprietario { get; set; }
        //public ProjectPermission Permissao { get; set; }

        public virtual Projeto? Projeto { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
