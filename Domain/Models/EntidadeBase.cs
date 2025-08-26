using System;

namespace TaskManager.Models
{
    public abstract class EntidadeBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string? CriadoPor { get; set; }
        public string? AtualizadoPor { get; set; }

        protected EntidadeBase()
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }
    }
}
