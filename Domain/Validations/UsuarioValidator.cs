using FluentValidation;
using TaskManager.Models;

namespace TaskManager.Validations
{
    /// <summary>
    /// Validação para entidade Usuário.
    /// </summary>
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.PrimeiroNome)
                .NotEmpty().WithMessage("O primeiro nome é obrigatório.")
                .MaximumLength(50).WithMessage("O primeiro nome deve ter no máximo 50 caracteres.");

            RuleFor(u => u.UltimoNome)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.")
                .MaximumLength(50).WithMessage("O sobrenome deve ter no máximo 50 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
        }
    }
}
