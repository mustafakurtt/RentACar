using FluentValidation;

namespace Application.Features.Types.Commands.Update;

public class UpdateTypeCommandValidator: AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator()
    {
        RuleFor(t => t.Id).NotNull().WithMessage("Id cannot be null");
        RuleFor(t => t.Id).NotEmpty().WithMessage("Id cannot be null");

        RuleFor(t => t.Name).NotNull().WithMessage("Name cannot be null");
        RuleFor(t => t.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(t => t.Name).MinimumLength(2).WithMessage("Name minimum length is 2");
        RuleFor(t => t.Name).MaximumLength(100).WithMessage("Name maximum length is 2");

    }
}