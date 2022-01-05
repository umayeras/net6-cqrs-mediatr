using FluentValidation;
using WebApp.Business.Commands;
using WebApp.Business.Constants;

namespace WebApp.Business.Validators;

public class AddSampleCommandValidator : AbstractValidator<AddSampleCommand>
{
    public AddSampleCommandValidator()
    {
        RuleFor(request => request.Title)
            .NotEmpty()
            .WithMessage(ValidationMessage.TitleRequired);
            
        RuleFor(request => request.Detail)
            .NotEmpty()
            .WithMessage(ValidationMessage.DetailRequired);
    }
}