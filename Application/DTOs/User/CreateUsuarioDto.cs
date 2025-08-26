namespace TaskManager.Application.DTOs.User
{
    public class CreateUsuarioDto
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string? UrlImagemPerfil { get; set; }
    }
}
