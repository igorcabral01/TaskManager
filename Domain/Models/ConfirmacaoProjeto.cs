using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models
{
    public class ConfirmacaoProjeto
    {
        [Key]
        public Guid ProjetoId { get; set; }
        public string? Nome { get; set; }
        public DateTime DataRecebimento { get; set; }
    }
}