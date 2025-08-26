namespace TaskManager.Application.DTOs.Project
{
    public class UpdateProjetoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool? Ativo { get; set; }
        public string? Cor { get; set; }
    }
}
