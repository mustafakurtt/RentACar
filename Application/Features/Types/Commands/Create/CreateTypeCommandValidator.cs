using FluentValidation;

namespace Application.Features.Types.Commands.Create;

public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator()
    {
        RuleFor(t => t.Name).NotNull().WithMessage("Name cannot be null");
        RuleFor(t => t.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(t => t.Name).MinimumLength(2).WithMessage("Name minimum length is 2");
        RuleFor(t => t.Name).MaximumLength(100).WithMessage("Name maximum length is 2");
    }
}