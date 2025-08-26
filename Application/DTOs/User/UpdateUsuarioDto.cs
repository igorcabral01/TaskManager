namespace TaskManager.Application.DTOs.User
{
    public class UpdateUsuarioDto
    {
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public string? Email { get; set; }
        public string? Perfil { get; set; }
        public string? UrlImagemPerfil { get; set; }
        public bool? Ativo { get; set; }
    }
}
