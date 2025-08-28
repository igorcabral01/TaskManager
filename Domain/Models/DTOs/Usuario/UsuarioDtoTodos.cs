using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Enums;

namespace TaskManager.Domain.Models.DTOs.Usuario
{
    public class UsuarioDtoTodos
    {
        public Guid UsuarioId { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; set; }
        public UserRole? Perfil { get; set; }
    }
}