using TaskManager.Enums;

namespace TaskManager.Application.DTOs.User
{
    public class UsuarioDto
    {
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; set; }
        public UserRole? Perfil { get; set; }
    }
}
