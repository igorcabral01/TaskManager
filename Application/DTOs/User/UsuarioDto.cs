namespace TaskManager.Application.DTOs.User
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public string? Email { get; set; }
        public string? UrlImagemPerfil { get; set; }
        public bool Ativo { get; set; }
        public string? Perfil { get; set; }
        public DateTime? UltimoLogin { get; set; }
    }
}
