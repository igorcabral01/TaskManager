using FluentValidation;
using TaskManager.Models;

namespace TaskManager.Validations
{
    public class ProjetoValidator : AbstractValidator<Projeto>
    {
        public ProjetoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do projeto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
        }
    }
}
