using FluentValidation;
using TaskManager.Models;

namespace TaskManager.Validations
{
    public class NotificacaoValidator : AbstractValidator<Notificacao>
    {
        public NotificacaoValidator()
        {
            RuleFor(n => n.Titulo)
                .NotEmpty().WithMessage("O título da notificação é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(n => n.Mensagem)
                .NotEmpty().WithMessage("A mensagem é obrigatória.")
                .MaximumLength(500).WithMessage("A mensagem deve ter no máximo 500 caracteres.");
        }
    }
}
