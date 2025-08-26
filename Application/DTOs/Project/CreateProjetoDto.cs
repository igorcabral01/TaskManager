namespace TaskManager.Application.DTOs.Project
{
    public class CreateProjetoDto
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Cor { get; set; }
    }
}
