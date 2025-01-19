using FluentValidation;

namespace Application.Features.Types.Commands.Delete;

public class DeleteTypeCommandValidator : AbstractValidator<DeleteTypeCommand>
{
    public DeleteTypeCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty().WithMessage("Id Cannot Be Empty");
        RuleFor(t => t.Id).NotNull().WithMessage("Id Cannot Be Null");
    }
}